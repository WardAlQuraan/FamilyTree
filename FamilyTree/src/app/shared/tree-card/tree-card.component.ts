import { Component, Input, OnInit } from '@angular/core';
import { Person } from 'src/app/Models/Tree/Person';
import { Tree } from 'src/app/Models/Tree/Tree';

@Component({
  selector: 'app-tree-card',
  templateUrl: './tree-card.component.html',
  styleUrls: ['./tree-card.component.css']
})
export class TreeCardComponent implements OnInit {
  @Input() person: Person;
  constructor() { }

  ngOnInit(): void {
  }

}
