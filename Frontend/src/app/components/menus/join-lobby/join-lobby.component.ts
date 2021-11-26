import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { LobbyConfig } from 'src/app/models/lobbyConfig';
import { LobbyListDataSource } from 'src/app/models/lobbyListDataSource';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';
import { TextInputDialogComponent } from '../../text-input-dialog/text-input-dialog.component';

@Component({
  selector: 'app-join-lobby',
  templateUrl: './join-lobby.component.html',
  styleUrls: ['./join-lobby.component.scss']
})
export class JoinLobbyComponent implements OnInit, OnDestroy {

  lobbiesSource: LobbyListDataSource;
  displayedColumns = ["name", "created-by", "private", "join"];
  password: string = '';

  constructor(private chessWebSocketService: ChessWebsocketService, private chessApiService: ChessAPIService,
              private router: Router, private snackBar: MatSnackBar, public dialog: MatDialog) { 
    this.lobbiesSource = new LobbyListDataSource(this.chessWebSocketService);
  }

  ngOnInit(): void {
    
  }

  ngOnDestroy(): void {

  }

  joinLobby(lobby: LobbyConfig): void {
    this.chessApiService.getLobbyConfig(lobby.name).subscribe((lobbyConfig: LobbyConfig) => {
      if (lobbyConfig != null) {
        this.router.navigate(['lobby', lobbyConfig.name])
      }
      else 
        this.snackBar.open("You can no longer join the selected lobby", 'Ok', { duration : 5000 })
    })
  }

  openDialog(lobby: LobbyConfig): void {
    const dialogRef = this.dialog.open(TextInputDialogComponent, {
      width: '250px',
      height: '250px',
      data: {title: 'Enter lobby password', label: 'Password', text: this.password, type: 'password'},
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.password = result;
        if (this.password == lobby.password)
          this.joinLobby(lobby);
        else 
          this.snackBar.open("Incorrect password", 'Ok', { duration : 5000 })
      }
    });
  }

}
