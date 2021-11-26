import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CookieService } from 'ngx-cookie-service';
import { AccountType } from 'src/app/models/accountType';
import { UserData } from 'src/app/models/userData';
import { ChessAPIService } from 'src/app/services/chess-api-service.service';
import { TextInputDialogComponent } from '../../text-input-dialog/text-input-dialog.component';

@Component({
  selector: 'app-starting-menu',
  templateUrl: './starting-menu.component.html',
  styleUrls: ['./starting-menu.component.scss']
})
export class StartingMenuComponent implements OnInit {

  isSignedIn: boolean = false;
  username: string = '';

  constructor(private oidcService: OidcSecurityService, private cookieService: CookieService,
    public dialog: MatDialog, private chessApiService: ChessAPIService) { 
    this.oidcService.userData$.subscribe((userData) => {
      console.log(userData.userData);
      if (userData.userData) {
        this.chessApiService.addRegisteredUser(userData.userData).subscribe((user: UserData) => {
          if (this.cookieService.check('user'))
            this.cookieService.delete('user');
          this.cookieService.set('user', btoa(JSON.stringify(user)));
        });
          this.isSignedIn = true;
      }
      else 
        this.isSignedIn = false;
    })
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(TextInputDialogComponent, {
      width: '250px',
      height: '250px',
      data: {title: 'Enter username', label: 'Your username', text: this.username, type: 'text'},
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        var newUser = new UserData(result);
        this.chessApiService.addTemporaryUser(newUser).subscribe((user: UserData) => {
        this.cookieService.set('user', btoa(JSON.stringify(user)));
        })
        this.isSignedIn = true;
      }
    });
  }

  ngOnInit(): void {
  }

  login(): void {
    this.oidcService.authorize();
  }

  logout(): void {
    var user = JSON.parse(atob(this.cookieService.get('user'))) as UserData;
    if (user.accountType == AccountType.Registered)
      this.oidcService.logoff();
    this.cookieService.delete('user');
    this.isSignedIn = false;
  }
}
