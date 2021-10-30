import { Component, OnInit, Input } from '@angular/core';
import { UserData } from 'src/app/models/userData';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.scss']
})
export class PlayerListComponent implements OnInit {

  @Input() public players: UserData[] = [];
  @Input() public title: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
