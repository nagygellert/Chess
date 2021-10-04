import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { Subject } from 'rxjs';
import { ChatMessage } from '../models/chatMessage';
import { ChessAPIService } from './chess-api-service.service';

@Injectable({
  providedIn: 'root'
})
export class ChessWebsocketService {

  private chessUrl = "https://localhost:44325/"
  private connection: signalR.HubConnection;
  chatMessages = new Subject<ChatMessage[]>();

  constructor(private chessAPI: ChessAPIService) { 
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:44325/hub")
      .build();
    this.init();
  }

  init() {
    this.connection.start().catch(err => console.log(err))
    this.connection.on("messageReceived", _ => {
      this.chessAPI.getChatMessages().subscribe(messages => this.chatMessages.next(messages))
    })
  }

  sendMessage(message: ChatMessage) {
    this.connection.send("newMessage", message);
  }

}
