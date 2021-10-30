import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ChatMessage } from 'src/app/models/chatMessage';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  chatMessages: ChatMessage[] = [];
  userData: UserData;
  newMessage: string = "";
  
  constructor(private oidcSecurityService: OidcSecurityService, private chessAPIClient: ChessAPIService, private socket: ChessWebsocketService) { 
    chessAPIClient.getChatMessages().subscribe(messages => this.chatMessages = messages);
    this.userData = JSON.parse(localStorage['user']) as UserData;
    this.socket.chatMessages.subscribe(message => {this.chatMessages = message; console.log(message)});
  }

  sendMessage() {
    //this.oidcSecurityService.userData$.subscribe(data => this.userData = data.userData as UserData);
    this.chessAPIClient.postChatMessage(new ChatMessage(this.userData, this.newMessage, new Date())).subscribe(_ => {
      this.socket.sendMessage();
    });
    this.newMessage = "";
  }

  ngOnInit(): void { }
}
