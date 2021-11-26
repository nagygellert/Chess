import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatComponent } from './components/chat/chat.component';
import { LobbyComponent } from './components/lobby/lobby.component';
import { StartingMenuComponent } from './components/menus/starting-menu/starting-menu.component';
import { AuthGuard } from './services/auth.service';
import { CreateLobbyComponent } from './components/menus/create-lobby/create-lobby.component';
import { JoinLobbyComponent } from './components/menus/join-lobby/join-lobby.component';
import { LobbyOwnerGuard } from './guards/can-deactivate-guard';
import { SignInGuard } from './guards/sign-in-guard';

const routes: Routes = [
  { path: '', component: StartingMenuComponent },
  { path: 'create-lobby', component: CreateLobbyComponent, canActivate: [AuthGuard] },
  { path: 'lobby/:lobbyName', component: LobbyComponent, canActivate: [SignInGuard], canDeactivate: [LobbyOwnerGuard] },
  { path: 'join', component: JoinLobbyComponent, canActivate: [SignInGuard] },
  { path: '**', component: StartingMenuComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
