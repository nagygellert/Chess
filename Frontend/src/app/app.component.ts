import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { UserData } from './models/userData';
import { ChessAPIService } from './services/chess-api-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  constructor (private oidcSecurityService: OidcSecurityService, private cookieService: CookieService,
              private chessApiService: ChessAPIService) {}
  title = 'Frontend';

  ngOnInit() {
    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken }) => {
      if (isAuthenticated) {

      }
    });
  }
}
