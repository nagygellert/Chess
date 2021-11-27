import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthenticatedResult, OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  isAuthenticated: boolean = false;

  constructor(private oidcService: OidcSecurityService, private router: Router) {
    this.oidcService.isAuthenticated$.subscribe((auth: AuthenticatedResult) => {
      this.isAuthenticated = auth.isAuthenticated;
    });
  }
  
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      if (this.isAuthenticated) {
        return true;
      }
      return this.router.navigateByUrl('/');
  }
} 