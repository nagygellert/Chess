import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { ChessPiece } from 'src/app/models/chessPiece';
import { Column } from 'src/app/models/column';
import { Move } from 'src/app/models/move';
import { PieceType } from 'src/app/models/pieceType';
import { Side } from 'src/app/models/side';
import { Tile } from 'src/app/models/tile';
import { Vote } from 'src/app/models/vote';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-chess-table',
  templateUrl: './chess-table.component.html',
  styleUrls: ['./chess-table.component.scss']
})
export class ChessTableComponent implements OnInit, OnChanges {

  rows: Array<number> = new Array(1, 2, 3, 4, 5, 6, 7, 8);
  columns: Array<Column> = new Array(Column.A, Column.B, Column.C, Column.D, Column.E, Column.F, Column.G, Column.H);
  board: Array<Tile> = [];
  @Input() moves: Array<Move> = [];
  @Input() side: Side = Side.White;
  @Input() canVote: boolean = false;
  @Output() vote: EventEmitter<Vote> = new EventEmitter();
  clickedTile?: Tile;
  previousTile?: Tile;
  pieceSelected: boolean = false;
  assetBaseUrl: string = `${environment.chessApiUrl}${environment.assetUrl}`;

  constructor(private chessApiService: ChessAPIService) {
    //this.initBoard();
   }

  tileClicked(tile: Tile): void {
    if (this.canVote) {
      this.previousTile = this.clickedTile;
      this.clickedTile = tile;
      if (this.pieceSelected) {
        this.vote.emit(new Vote(new Move(this.previousTile!, this.clickedTile)));
        this.pieceSelected = false;
        this.previousTile = this.clickedTile = undefined;
      }
      else if (this.clickedTile.chessPiece) {
        this.pieceSelected = true;
      }
      else 
        this.pieceSelected = false;
    }
  } 

  ngOnChanges(changes: any) {
    if (changes.moves) {
      this.playMoves()
    }
  }

  playMove(move: Move): void {
    console.log(move);
    var fromTile = this.board.find(tile => tile.column == move.from.column && tile.row == move.from.row);
    var toTile = this.board.find(tile => tile.column == move.to.column && tile.row == move.to.row);
    console.log(fromTile);
    console.log(toTile);
    toTile!.chessPiece = new ChessPiece(fromTile!.chessPiece!.type, fromTile!.chessPiece!.side, fromTile!.chessPiece!.iconUrl);
    fromTile!.chessPiece = undefined;
  }

  playMoves() {
    this.initBoard();
    this.moves.sort((x: Move, y: Move) => new Date(x.createdAt).getTime() - new Date(x.createdAt).getTime()).forEach((move: Move) => {
      this.playMove(move);
    });
  }

  initBoard(): void {
    this.board = [];
    this.board.push(new Tile(8, Column.A, new ChessPiece(PieceType.Rook, Side.White, this.assetBaseUrl + "/white-rook.svg")),
    new Tile(8, Column.B, new ChessPiece(PieceType.Knight, Side.White, this.assetBaseUrl + "/white-knight.svg")),
    new Tile(8, Column.C, new ChessPiece(PieceType.Bishop, Side.White, this.assetBaseUrl + "/white-bishop.svg")),
    new Tile(8, Column.D, new ChessPiece(PieceType.Queen, Side.White, this.assetBaseUrl + "/white-queen.svg")),
    new Tile(8, Column.E, new ChessPiece(PieceType.King, Side.White, this.assetBaseUrl + "/white-king.svg")),
    new Tile(8, Column.F, new ChessPiece(PieceType.Bishop, Side.White, this.assetBaseUrl + "/white-bishop.svg")),
    new Tile(8, Column.G, new ChessPiece(PieceType.Knight, Side.White, this.assetBaseUrl + "/white-knight.svg")),
    new Tile(8, Column.H, new ChessPiece(PieceType.Rook, Side.White, this.assetBaseUrl + "/white-rook.svg")));
    this.columns.forEach((col: Column) => {
      this.board.push(new Tile(7, col, new ChessPiece(PieceType.Pawn, Side.White, this.assetBaseUrl + "/white-pawn.svg")));
    })
    for (let row = 6; row > 2; row--) {
      this.columns.forEach((col: Column) => {
        this.board.push(new Tile(row, col));
      });
    }
    this.columns.forEach((col: Column) => {
      this.board.push(new Tile(2, col, new ChessPiece(PieceType.Pawn, Side.Black, this.assetBaseUrl + "/black-pawn.svg")));
    })
    this.board.push(new Tile(1, Column.A, new ChessPiece(PieceType.Rook, Side.Black, this.assetBaseUrl + "/black-rook.svg")),
    new Tile(1, Column.B, new ChessPiece(PieceType.Knight, Side.Black, this.assetBaseUrl + "/black-knight.svg")),
    new Tile(1, Column.C, new ChessPiece(PieceType.Bishop, Side.Black, this.assetBaseUrl + "/black-bishop.svg")),
    new Tile(1, Column.D, new ChessPiece(PieceType.Queen, Side.Black, this.assetBaseUrl + "/black-queen.svg")),
    new Tile(1, Column.E, new ChessPiece(PieceType.King, Side.Black, this.assetBaseUrl + "/black-king.svg")),
    new Tile(1, Column.F, new ChessPiece(PieceType.Bishop, Side.Black, this.assetBaseUrl + "/black-bishop.svg")),
    new Tile(1, Column.G, new ChessPiece(PieceType.Knight, Side.Black, this.assetBaseUrl + "/black-knight.svg")),
    new Tile(1, Column.H, new ChessPiece(PieceType.Rook, Side.Black, this.assetBaseUrl + "/black-rook.svg")));
    if (this.side == Side.White)
      this.board = this.board.reverse();
  }

  ngOnInit(): void {
  }

}
