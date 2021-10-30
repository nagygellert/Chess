import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';

import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    constructor(private oidcSecurityService: OidcSecurityService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.oidcSecurityService.isAuthenticated()) {
          const authReq = req.clone({
            headers: req.headers.set('Authorization', `Bearer ${this.oidcSecurityService.getAccessToken()}`)
          });
          return next.handle(authReq);
        }
        return next.handle(req);
  }
}