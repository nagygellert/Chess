import { CanDeactivate } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ComponentCanDeactivate } from '../models/componentCanDeactivate';

@Injectable()
export class LobbyOwnerGuard implements CanDeactivate<LobbyOwnerGuard> {
  canDeactivate(component: ComponentCanDeactivate): boolean | Observable<boolean> {
    return component.canDeactivate() ?
      true :
      confirm('WARNING: You are the lobby owner. If you leave this page, the lobby will be destroyed and the players within will be redirected to the lobby list page.');
  }
}