import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './components/chat/chat.component';
import { JoinGameComponent } from './components/join-game/join-game.component';
import { LobbyComponent } from './components/lobby/lobby.component';
import { StartingMenuComponent } from './components/menus/starting-menu/starting-menu.component';
import { AuthGuard } from './services/auth.service';
import { CreateLobbyComponent } from './components/menus/create-lobby/create-lobby.component';
import { JoinLobbyComponent } from './components/menus/join-lobby/join-lobby.component';

const routes: Routes = [
  { path: '', component: StartingMenuComponent },
  { path: 'create-lobby', component: CreateLobbyComponent, canActivate: [AuthGuard] },
  { path: 'lobby', component: LobbyComponent },
  { path: 'join', component: JoinLobbyComponent},
  { path: '**', component: StartingMenuComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
