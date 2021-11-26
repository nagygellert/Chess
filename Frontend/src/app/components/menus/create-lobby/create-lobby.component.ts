import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { LobbyConfig } from 'src/app/models/lobbyConfig';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';

@Component({
  selector: 'app-create-lobby',
  templateUrl: './create-lobby.component.html',
  styleUrls: ['./create-lobby.component.scss']
})
export class CreateLobbyComponent implements OnInit {

  isPrivate: boolean = false;
  lobbyName: string = '';
  password?: string;

  constructor(private chessApiService: ChessAPIService, private cookieService: CookieService,
              private chessWebsocket: ChessWebsocketService, private router: Router, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
  }

  createLobby(): void {
    var newLobby = new LobbyConfig();
    newLobby.isPrivate = this.isPrivate;
    newLobby.name = this.lobbyName;
    if (this.isPrivate)
      newLobby.password = this.password;
    newLobby.owner = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
    this.chessApiService.createLobby(newLobby).subscribe((config: LobbyConfig) => {
      if (config) {
        var conn = this.chessWebsocket.getConnection("lobbylisthub");
        conn.start()
        .then(() => conn.invoke('LobbyCreated'))
        .finally(() => conn.stop());
        this.cookieService.set('user', btoa(JSON.stringify(config.owner)));
        this.router.navigate(['lobby', config.name]);
      }
      else {
        this.snackBar.open("A lobby with the given name already exists!", 'Ok', { duration : 5000 })
      }
    });
  }

}
