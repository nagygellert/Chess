import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChatMessage } from '../models/chatMessage';
import { LobbyConfig } from '../models/lobbyConfig';
import { UserData } from '../models/userData';

@Injectable({
  providedIn: 'root'
})
export class ChessAPIService {

  private chessUrl = environment.chessApiUrl;

  constructor(private httpClient: HttpClient) { }

  getChatMessages(): Observable<ChatMessage[]> {
    return this.httpClient.get<ChatMessage[]>(`${this.chessUrl}/ChatMessage`);
  }

  postChatMessage(chatMessage: ChatMessage): Observable<ChatMessage> {
    return this.httpClient.post<ChatMessage>(`${this.chessUrl}/ChatMessage`, chatMessage, {headers: {'content-type': 'application/json'}});
  }

  createLobby(creator: UserData): Observable<LobbyConfig> {
    return this.httpClient.post<LobbyConfig>(`${this.chessUrl}/Lobby`, creator, {headers: {'content-type': 'application/json'}});
  }

  joinLobby(roomCode: number, player: UserData): Observable<UserData> {
    return this.httpClient.post<UserData>(`${this.chessUrl}/user/temporary`, player, {headers: {'content-type': 'application/json'}, params: {'roomCode': roomCode.toString()}});
  }

  getLobbyConfig(roomCode: number): Observable<LobbyConfig> {
    return this.httpClient.get<LobbyConfig>(`${this.chessUrl}/Lobby/${roomCode}/config`,);
  }

  addRegisteredUser(userData: UserData | undefined): Observable<UserData> {
    return this.httpClient.post<UserData>(`${this.chessUrl}/user/registered`, userData, {headers: {'content-type': 'application/json'}});
  }
}
