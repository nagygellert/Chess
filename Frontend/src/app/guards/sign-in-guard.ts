import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { AccountType } from '../models/accountType';
import { UserData } from '../models/userData';

@Injectable({
  providedIn: 'root'
})
export class SignInGuard implements CanActivate {

    isLoggedIn: boolean = false;

    constructor(private cookieService: CookieService, private router: Router, private oidcService: OidcSecurityService) {
        this.oidcService.isAuthenticated$.subscribe((auth) => this.isLoggedIn = auth.isAuthenticated);
    }
    
    canActivate(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
        if (this.cookieService.check('user')) {
            var user = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
            if (user.accountType == AccountType.Temporary || (user.accountType == AccountType.Registered && this.isLoggedIn))
                return true;
        }
        return this.router.navigateByUrl('/');
    }
} 