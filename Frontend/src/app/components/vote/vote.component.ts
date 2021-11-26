import { Component, Input, OnInit } from '@angular/core';
import { Vote } from 'src/app/models/vote';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  @Input() votes: Vote[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
