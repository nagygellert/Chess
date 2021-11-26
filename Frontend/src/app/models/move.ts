import { Tile } from "./tile";

export class Move {
    from: Tile;
    to: Tile;
    createdAt: Date;

    constructor(from: Tile, to: Tile, createdAt: Date = new Date()) {
        this.from = from;
        this.to = to;
        this.createdAt = createdAt;
    }
}