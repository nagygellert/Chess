import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor (private oidcSecurityService: OidcSecurityService, private cookieService: CookieService) {}
  title = 'Frontend';

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken }) => {
      this.cookieService.set('user', btoa(JSON.stringify(userData)));
      console.log(userData);
    });
  }
}
