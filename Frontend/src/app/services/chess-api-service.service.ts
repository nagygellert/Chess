import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { ChatMessage } from '../models/chatMessage';

@Injectable({
  providedIn: 'root'
})
export class ChessAPIService {

  private chessUrl = "https://localhost:44325/"

  constructor(private httpClient: HttpClient) { }

  getChatMessages(): Observable<ChatMessage[]> {
    return this.httpClient.get<ChatMessage[]>(this.chessUrl + "ChatMessage");
  }

  postChatMessage(chatMessage: ChatMessage) {
    return this.httpClient.post<ChatMessage>(this.chessUrl + "ChatMessage", chatMessage).subscribe();
  }
}
