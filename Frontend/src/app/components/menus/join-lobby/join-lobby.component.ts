import { Component, OnInit } from '@angular/core';
import { LobbyConfig } from 'src/app/models/lobbyConfig';

@Component({
  selector: 'app-join-lobby',
  templateUrl: './join-lobby.component.html',
  styleUrls: ['./join-lobby.component.scss']
})
export class JoinLobbyComponent implements OnInit {

  lobbies: LobbyConfig[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
