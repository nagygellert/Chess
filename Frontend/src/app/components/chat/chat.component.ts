import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { stringify } from 'querystring';
import { ChatMessage } from 'src/app/models/chatMessage';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit, OnDestroy {

  userData: UserData;
  connection: signalR.HubConnection;
  chatMessages: ChatMessage[] = [];
  newMessage: string = "";
  @Input() lobbyName: string = '';
  
  constructor(private cookieService: CookieService, private chessAPIClient: ChessAPIService, private socket: ChessWebsocketService) {
    this.connection = this.socket.getConnection('chathub');
    this.userData = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
  }

  sendMessage() {
    this.connection.invoke('NewMessage', new ChatMessage(this.userData, this.newMessage, new Date()), this.lobbyName,);
    this.newMessage = "";
  }

  ngOnInit(): void { 
    this.connection.on('SetMessages', (messages: ChatMessage[]) => {
      this.chatMessages = messages;
    });
    this.connection.on('SetMessage', (message: ChatMessage) => {
      this.chatMessages.push(message);
    });
    this.connection.start().then(() => this.connection.invoke('EnteredChat', this.lobbyName));
  }

  ngOnDestroy(): void {
    this.connection.off("SetMessages");
    this.connection.off("SetMessage");
    this.connection.stop();
  }
}
