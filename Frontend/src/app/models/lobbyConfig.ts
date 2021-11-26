import { UserData } from "./userData";

export class LobbyConfig {
    owner: UserData = new UserData();
    whiteTeamPlayers: UserData[] = [];
    blackTeamPlayers: UserData[] = [];
    name: string = '';
    round: number = 1;
    gameStarted: boolean = false;
    isPrivate: boolean = false;
    password?: string;
}