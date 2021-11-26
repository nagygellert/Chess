import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { ChatMessage } from '../models/chatMessage';
import { LobbyConfig } from '../models/lobbyConfig';
import { UserData } from '../models/userData';
import { Vote } from '../models/vote';

@Injectable({
  providedIn: 'root'
})
export class ChessAPIService {

  private chessUrl = environment.chessApiUrl;

  constructor(private httpClient: HttpClient) { }

  getChatMessages(): Observable<ChatMessage[]> {
    return this.httpClient.get<ChatMessage[]>(`${this.chessUrl}/Chat`);
  }

  postChatMessage(chatMessage: ChatMessage): Observable<ChatMessage> {
    return this.httpClient.post<ChatMessage>(`${this.chessUrl}/Chat`, chatMessage, {headers: {'content-type': 'application/json'}});
  }

  createLobby(config: LobbyConfig): Observable<LobbyConfig> {
    return this.httpClient.post<LobbyConfig>(`${this.chessUrl}/Lobby`, config, {headers: {'content-type': 'application/json'}});
  }

  deleteLobby(lobbyName: string) {
    return this.httpClient.delete(`${this.chessUrl}/Lobby/${lobbyName}`, {headers: {'content-type': 'application/json'}});
  }

  joinLobby(roomCode: number, player: UserData): Observable<UserData> {
    return this.httpClient.post<UserData>(`${this.chessUrl}/user/temporary`, player, {headers: {'content-type': 'application/json'}, params: {'roomCode': roomCode.toString()}});
  }

  postVote(vote: Vote, playerId: string): Observable<Vote> {
    return this.httpClient.post<Vote>(`${this.chessUrl}/vote`, vote, {headers: {'content-type': 'application/json'}, params: {'userId': playerId }});
  }

  getLobbyConfig(lobbyName: string): Observable<LobbyConfig> {
    return this.httpClient.get<LobbyConfig>(`${this.chessUrl}/Lobby/${lobbyName}/config`);
  }

  getLobbyConfigs(): Observable<LobbyConfig[]> {
    return this.httpClient.get<LobbyConfig[]>(`${this.chessUrl}/Lobby`);
  }

  addRegisteredUser(userData: UserData): Observable<UserData> {
    return this.httpClient.post<UserData>(`${this.chessUrl}/user/registered`, userData, {headers: {'content-type': 'application/json'}});
  }

  addTemporaryUser(userData: UserData): Observable<UserData> {
    return this.httpClient.post<UserData>(`${this.chessUrl}/user/temporary`, userData, {headers: {'content-type': 'application/json'}});
  }
}
