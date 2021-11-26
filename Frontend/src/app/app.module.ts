import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ChatComponent } from './components/chat/chat.component';
import { httpInterceptorProviders } from './interceptors/http-interceptors';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { PlayerListComponent } from './components/player-list/player-list.component';
import { LobbyComponent } from './components/lobby/lobby.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatGridListModule } from '@angular/material/grid-list'
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';
import { CreateLobbyComponent } from './components/menus/create-lobby/create-lobby.component';
import { JoinLobbyComponent } from './components/menus/join-lobby/join-lobby.component';
import { StartingMenuComponent } from './components/menus/starting-menu/starting-menu.component';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';
import { TextInputDialogComponent } from './components/text-input-dialog/text-input-dialog.component';
import { LobbyOwnerGuard } from './guards/can-deactivate-guard';
import { ChessTableComponent } from './components/chess-table/chess-table.component';
import { ColumnNamePipe } from './pipes/column-name.pipe';
import { VoteComponent } from './components/vote/vote.component';

@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,
    PlayerListComponent,
    LobbyComponent,
    CreateLobbyComponent,
    JoinLobbyComponent,
    StartingMenuComponent,
    TextInputDialogComponent,
    ChessTableComponent,
    ColumnNamePipe,
    VoteComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatGridListModule,
    MatCheckboxModule,
    MatSnackBarModule,
    MatOptionModule,
    MatTableModule,
    MatRadioModule,
    MatSelectModule,
    MatDialogModule,
    BrowserAnimationsModule,
    AuthModule.forRoot({
      config: {
          authority: environment.identityServerUrl,
          redirectUrl: 'http://localhost:4200',
          postLogoutRedirectUri: window.location.origin,
          clientId: 'chessAngular',
          scope: 'chessAPI openid profile offline_access',
          responseType: 'code',
          silentRenew: true,
          useRefreshToken: true,
          logLevel: LogLevel.Debug
      }
    }),
  ],
  providers: [httpInterceptorProviders, CookieService, LobbyOwnerGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
