import { UserData } from "./userData";

export class LobbyConfig {
    owner: UserData = new UserData();
    players: UserData[] = [];
    isPrivate: boolean = false;
    password?: string;
}