import { UserData } from "./userData";

export class LobbyConfig {
    owner: UserData = new UserData();
    players: UserData[] = [];
    roomCode: number = 0;
}