import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userName: string = "";

  constructor(private router: Router) { }

  registerUser() {
    localStorage.setItem("userName", this.userName);
    this.router.navigateByUrl("/chat")
  }

  ngOnInit(): void {
  }

}
