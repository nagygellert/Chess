import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LobbyConfig } from 'src/app/models/lobbyConfig';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Component({
  selector: 'app-join-game',
  templateUrl: './join-game.component.html',
  styleUrls: ['./join-game.component.scss']
})
export class JoinGameComponent implements OnInit {

  selectedSide = '1';
  username = '';
  roomCode = '';

  constructor(private router: Router, private chessApiService: ChessAPIService, private snackBar: MatSnackBar) {}

  ngOnInit(): void {
  }

  onSubmit() {
    console.log('submit');
    this.chessApiService.getLobbyConfig(Number.parseInt(this.roomCode)).subscribe((config: LobbyConfig) => {
      if (config != null) {
        console.log('nem null');
        var tempUser = new UserData();
        tempUser.name = this.username;
        tempUser.side = Number.parseInt(this.selectedSide);
        this.chessApiService.joinLobby(Number.parseInt(this.roomCode), tempUser).subscribe((tempUser: UserData) => localStorage.setItem('user', JSON.stringify(tempUser)));
        this.router.navigateByUrl(`/lobby`);
      }
      else 
        this.snackBar.open(`Lobby ${this.roomCode} does not exist!`, 'Ok', { duration: 2000});
    })
  }

}
