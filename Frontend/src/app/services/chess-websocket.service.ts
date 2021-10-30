import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ChatMessage } from '../models/chatMessage';
import { ChessAPIService } from './chess-api-service.service';

@Injectable({
  providedIn: 'root'
})
export class ChessWebsocketService {

  private chessUrl = environment.chessApiUrl;
  private connection: signalR.HubConnection;
  chatMessages = new Subject<ChatMessage[]>();

  constructor(private chessAPI: ChessAPIService, private oidcService: OidcSecurityService) { 
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(`${this.chessUrl}/hub`, { accessTokenFactory: () => this.oidcService.getAccessToken()})
      .build();
    this.init();
    console.log('konstruktor');
  }

  init() {
    this.connection.start().catch(err => console.log(err))
    this.connection.on("messageReceived", _ => {
      console.log(this.chatMessages);
      this.chessAPI.getChatMessages().subscribe(messages => this.chatMessages.next(messages))
    })
  }

  sendMessage() {
    this.connection.send("newMessage");
  }

}
