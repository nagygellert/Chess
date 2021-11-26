import { AccountType } from "./accountType";
import { Side } from "./side";

export class UserData {
    id?: string;
    name: string;
    sub?: string;
    side?: Side;
    lobbyName?: string;
    accountType?: AccountType;

    constructor(name: string = '') {
        this.name = name;
    }
}