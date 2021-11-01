import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OidcSecurityService, UserDataResult } from 'angular-auth-oidc-client';
import { AuthOptions } from 'angular-auth-oidc-client';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isLoggedIn: boolean = false;
  user: UserData | undefined;

  constructor(private oidcSecurityService: OidcSecurityService, private router: Router, private chessApiService: ChessAPIService) {
    this.isLoggedIn = this.oidcSecurityService.isAuthenticated();
    this.oidcSecurityService.isAuthenticated$.subscribe(res => this.isLoggedIn = res.isAuthenticated);
    this.oidcSecurityService.userData$.subscribe(res => {
      this.user = res.userData; 
      console.log(this.user);
      if (this.isLoggedIn) {
      this.chessApiService.addRegisteredUser(this.user).subscribe((data: UserData) => {
        localStorage.setItem('user', JSON.stringify(data));
      });
    }
    });
   }

  registerUser() {
      this.oidcSecurityService.authorize();
  }

  ngOnInit(): void {
  }

}
