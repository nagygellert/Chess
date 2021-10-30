import { Component, DoCheck, Input, OnInit } from '@angular/core';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { LobbyConfig } from 'src/app/models/lobbyConfig';

@Component({
  selector: 'app-lobby',
  templateUrl: './lobby.component.html',
  styleUrls: ['./lobby.component.scss']
})
export class LobbyComponent implements OnInit {

  public user: UserData;
  lobbyConfig?: LobbyConfig;

  constructor(private chessApiService: ChessAPIService) {
    this.user = JSON.parse(localStorage['user']);
   }

  ngOnInit(): void {
  }

  createLobby(): void {
    this.chessApiService.createLobby(this.user).subscribe((config: LobbyConfig) => {
      this.lobbyConfig = config;
    });
  }
}
