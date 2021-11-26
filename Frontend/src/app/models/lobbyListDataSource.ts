import { CollectionViewer, DataSource } from "@angular/cdk/collections";
import { LobbyConfig } from "./lobbyConfig";
import { Observable, BehaviorSubject, Subscription, interval } from "rxjs";
import { ChessAPIService } from "../services/chess-api-service.service";
import { ChessWebsocketService } from "../services/chess-websocket.service";

export class LobbyListDataSource implements DataSource<LobbyConfig> {

    private lobbiesSubject = new BehaviorSubject<LobbyConfig[]>([]);
    private updateLobbies: Subscription;
    connection: signalR.HubConnection;

    constructor(private chessWebSocket: ChessWebsocketService) {
        this.connection = this.chessWebSocket.getConnection('lobbylisthub');
        this.updateLobbies = interval(5000).subscribe(() => this.connection.invoke('UpdateLobbies'));
    }

    connect(collectionViewer: CollectionViewer): Observable<LobbyConfig[]> {
        this.connection.on('SetLobbies', (lobbies: LobbyConfig[]) => {
            this.lobbiesSubject.next(lobbies);
        });
        this.connection.start()
            .then(() => this.connection.invoke('EnterLobbySearch'));
        
        return this.lobbiesSubject.asObservable();
    } 

    disconnect(collectionViewer: CollectionViewer): void {
        this.updateLobbies.unsubscribe();
        this.connection.off('SetLobbies');
        this.connection.stop();
    }
}