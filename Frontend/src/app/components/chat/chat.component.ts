import { Component, OnInit } from '@angular/core';
import { ChatMessage } from 'src/app/models/chatMessage';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  chatMessages: ChatMessage[] = [];
  newMessage: string = "";
  
  constructor(private chessAPIClient: ChessAPIService, private socket: ChessWebsocketService) { 
    chessAPIClient.getChatMessages().subscribe(messages => this.chatMessages = messages);
    this.socket.chatMessages.subscribe(message => this.chatMessages = message);
  }

  sendMessage() {
    this.socket.sendMessage(new ChatMessage(localStorage.getItem("userName")!, this.newMessage, new Date()));
    this.newMessage = "";
  }

  ngOnInit(): void { }
}
