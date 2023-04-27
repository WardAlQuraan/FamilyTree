import { Component, OnInit } from '@angular/core';
import { Family } from 'src/app/Models/Family/Family';
import { FamilyService } from 'src/app/Services/Family/family.service';

@Component({
  selector: 'app-families',
  templateUrl: './families.component.html',
  styleUrls: ['./families.component.css']
})
export class FamiliesComponent implements OnInit {

  families:Family[];

  constructor(private familyService:FamilyService) { }

  ngOnInit(): void {
    this.familyService.getAll().subscribe(data=>{
      this.families = data;
    })
  }

}
