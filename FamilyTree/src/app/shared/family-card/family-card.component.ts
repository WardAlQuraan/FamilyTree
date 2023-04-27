import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Family } from 'src/app/Models/Family/Family';

@Component({
  selector: 'app-family-card',
  templateUrl: './family-card.component.html',
  styleUrls: ['./family-card.component.css']
})
export class FamilyCardComponent implements OnInit {
  @Input() family: Family;


  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  routingToTree(id:number){
    this.router.navigateByUrl("tree/"+id);
  }
}
