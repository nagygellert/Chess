import { PieceType } from "./pieceType";
import { Side } from "./side";

export class ChessPiece {
    iconUrl: string = '';
    side: Side = Side.White;
    type: PieceType = PieceType.Pawn;

    constructor(type: PieceType = PieceType.Pawn, side: Side = Side.White, iconUrl: string = '') {
        this.type = type;
        this.side = side;
        this.iconUrl = iconUrl;
    }
}