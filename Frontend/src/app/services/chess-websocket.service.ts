import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';
import { UserData } from '../models/userData';

@Injectable({
  providedIn: 'root'
})
export class ChessWebsocketService {
  constructor(private cookieService: CookieService) {}
  private chessUrl = environment.chessApiUrl;

  getConnection(hubUrl: string): signalR.HubConnection {
    var userData = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
    return new signalR.HubConnectionBuilder()
    .withUrl(`${this.chessUrl}/${hubUrl}?userId=${userData.id}`)
    .build();
  }
}
