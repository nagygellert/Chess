import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-starting-menu',
  templateUrl: './starting-menu.component.html',
  styleUrls: ['./starting-menu.component.scss']
})
export class StartingMenuComponent implements OnInit {

  isSignedIn: boolean = false;

  constructor(private oidcService: OidcSecurityService) { 
    this.oidcService.isAuthenticated$.subscribe((result) => {
      this.isSignedIn = result.isAuthenticated
    })
  }

  ngOnInit(): void {
  }

  login(): void {
    this.oidcService.authorize();
  }

  logout(): void {
    this.oidcService.logoff();
  }

}
