import { ChessPiece } from "./chessPiece";
import { Column } from "./column";

export class Tile {
    row: number = 1;
    column: Column = Column.A;
    chessPiece?: ChessPiece;

    constructor(row: number = 1, col: Column = Column.A, piece?: ChessPiece) {
        this.row = row;
        this.column = col;
        this.chessPiece = piece;
    }
}