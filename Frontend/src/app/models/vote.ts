import { Move } from "./move";
import { UserData } from "./userData";

export class Vote {
    move: Move;
    round: number;
    lobbyName: string;
    user: UserData;

    constructor(move: Move, round: number = 0, lobbyName: string = '', user: UserData = new UserData()) {
        this.move = move;
        this.round = round;
        this.lobbyName = lobbyName;
        this.user = user;
    }
}