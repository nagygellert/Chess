import { Component, DoCheck, HostListener, Input, OnDestroy, OnInit } from '@angular/core';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { LobbyConfig } from 'src/app/models/lobbyConfig';
import { ActivatedRoute, Router } from '@angular/router';
import { ChessWebsocketService } from 'src/app/services/chess-websocket.service';
import { CookieService } from 'ngx-cookie-service';
import { ComponentCanDeactivate } from 'src/app/models/componentCanDeactivate';
import { interval, Observable, Subscriber } from 'rxjs';
import { Side } from 'src/app/models/side';
import { Tile } from 'src/app/models/tile';
import { Move } from 'src/app/models/move';
import { Vote } from 'src/app/models/vote';

@Component({
  selector: 'app-lobby',
  templateUrl: './lobby.component.html',
  styleUrls: ['./lobby.component.scss']
})
export class LobbyComponent implements OnInit, OnDestroy, ComponentCanDeactivate {

  lobbyConfig: LobbyConfig = new LobbyConfig();
  lobbyName: string = '';
  user: UserData;
  playerSide: Side = Side.White;
  remainingTime: number = 20;
  remainingTime$: Observable<number>;
  votes: Vote[] = [];
  board: Array<Tile> = [];
  moves: Array<Move> = [];
  canVote: boolean = true;
  connection: signalR.HubConnection;

  constructor(private chessApiService: ChessAPIService, private route: ActivatedRoute, 
            private chessWebsocket: ChessWebsocketService, private cookieService: CookieService,
            private router: Router) {
    this.lobbyName = route.snapshot.paramMap.get('lobbyName')!;
    this.connection = this.chessWebsocket.getConnection('lobbyhub');
    this.user = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
    this.chessApiService.getLobbyConfig(this.lobbyName).subscribe((config: LobbyConfig) => {
      this.lobbyConfig = config;
    });
    this.remainingTime$ = new Observable((subscriber: Subscriber<number>) => {
      setInterval(() => {
        subscriber.next(this.remainingTime);
        if (this.remainingTime > 0)
          this.remainingTime -= 1;
      }, 1000);
    });
  }

  castVote(vote: Vote): void {
    vote.user = this.user;
    vote.round = this.lobbyConfig.round;
    vote.lobbyName = this.lobbyName;
    this.connection.invoke("AddVote", vote);
  }

  swapPlayerSide(): void {
    this.connection.invoke("SwapSides", this.user, this.lobbyName);
  }

  startGame() {
    this.connection.invoke('StartGame', this.lobbyName);
  }

  @HostListener('window:beforeunload')
  canDeactivate(): boolean | Observable<boolean> {
    return this.lobbyConfig.gameStarted === true || this.user.id !== this.lobbyConfig?.owner.id;
  }

  ngOnInit(): void {
    this.connection.on('SetLobby', (lobbyData: LobbyConfig) => {
      if (lobbyData) {
        if (!this.lobbyConfig.gameStarted && lobbyData.gameStarted)
          if (this.lobbyConfig.blackTeamPlayers.find((user: UserData) => user.id === this.user.id)) {
            this.playerSide = Side.Black;
            this.canVote = false;
          }
        this.lobbyConfig = lobbyData
      }

      else 
        this.router.navigate(['join']);
    });
    this.connection.on('SetRoundEnd', (roundEnd) => {
      this.remainingTime = Math.round((new Date(roundEnd).getTime() - new Date().getTime()) / 1000);
      this.canVote = !this.canVote;
      this.votes = new Array<Vote>();
    })
    this.connection.on('SetMoves', (moves: Array<Move>) => {
      this.lobbyConfig.round++;
      this.moves = moves; 
    })
    this.connection.on('SetVotes', (votes: Array<Vote>) => {
      this.votes = votes; 
    })
    this.connection.on('PlayerJoined', (userData: UserData) => {
      if (userData.side == Side.White)
        this.lobbyConfig.whiteTeamPlayers.push(userData);
      else
        this.lobbyConfig.blackTeamPlayers.push(userData);
    });
    this.connection.on('PlayerLeft', (userData: UserData) => {
      this.lobbyConfig.whiteTeamPlayers = this.lobbyConfig.whiteTeamPlayers.filter(p => p.id != userData.id);
      this.lobbyConfig.blackTeamPlayers = this.lobbyConfig.blackTeamPlayers.filter(p => p.id != userData.id);
    });
    this.connection.on('OwnerLeft', () => {
      this.router.navigate(['join'])
    });
    this.connection.start().then(() => this.connection.invoke('EnterLobby', this.user, this.lobbyName));
  }

  ngOnDestroy(): void {
    this.connection.off('SetLobby');
    this.connection.off('SetRoundEnd');
    this.connection.off('PlayerJoined');
    this.connection.off('SetMoves');
    this.connection.off('SetVotes');
    this.connection.off('PlayerLeft');
    this.connection.off('OwnerLeft');
    this.connection.stop();
  }

}
