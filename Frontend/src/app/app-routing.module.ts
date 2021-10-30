import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './components/chat/chat.component';
import { JoinGameComponent } from './components/join-game/join-game.component';
import { LobbyComponent } from './components/lobby/lobby.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './services/auth.service';

const routes: Routes = [
  { path: 'chat', component: ChatComponent, canActivate: [AuthGuard] },
  { path: 'home', component: LoginComponent },
  { path: 'lobby', component: LobbyComponent },
  { path: 'join', component: JoinGameComponent},
  { path: '**', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
