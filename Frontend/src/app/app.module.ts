import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthModule, LogLevel } from 'angular-auth-oidc-client';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ChatComponent } from './components/chat/chat.component';
import { LoginComponent } from './components/login/login.component';
import { httpInterceptorProviders } from './interceptors/http-interceptors';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { PlayerListComponent } from './components/player-list/player-list.component';
import { LobbyComponent } from './components/lobby/lobby.component';
import { JoinGameComponent } from './components/join-game/join-game.component';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,
    LoginComponent,
    PlayerListComponent,
    LobbyComponent,
    JoinGameComponent
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
    MatCheckboxModule,
    MatSnackBarModule,
    MatOptionModule,
    MatRadioModule,
    MatSelectModule,
    BrowserAnimationsModule,
    AuthModule.forRoot({
      config: {
          authority: environment.identityServerUrl,
          redirectUrl: 'http://localhost:4200/login',
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
  providers: [httpInterceptorProviders, CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
