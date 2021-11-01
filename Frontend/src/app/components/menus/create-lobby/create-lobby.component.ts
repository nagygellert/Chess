import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-create-lobby',
  templateUrl: './create-lobby.component.html',
  styleUrls: ['./create-lobby.component.scss']
})
export class CreateLobbyComponent implements OnInit {

  isPrivate: boolean = false;
  lobbyName: string = '';
  password?: string;

  constructor() { }

  ngOnInit(): void {
  }

  createLobby(): void {

  }

}
