import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr";
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';
import { UserData } from '../models/userData';

@Injectable({
  providedIn: 'root'
})
export class ChessWebsocketService {
  constructor(private cookieService: CookieService, private oidcService: OidcSecurityService) {}
  private chessUrl = environment.chessApiUrl;

  getConnection(hubUrl: string): signalR.HubConnection {
    var userData = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
    return new signalR.HubConnectionBuilder()
    .withUrl(`${this.chessUrl}/${hubUrl}?userId=${userData.id}`, { accessTokenFactory: () => this.oidcService.getAccessToken() })
    .build();
  }
}
