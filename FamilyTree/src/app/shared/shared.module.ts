import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import { FamilyCardComponent } from './family-card/family-card.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { TreeCardComponent } from './tree-card/tree-card.component';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  declarations: [
    FamilyCardComponent,
    TreeCardComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    RouterModule
  ],
  exports:[
    MatCardModule,
    MatButtonModule,
    FamilyCardComponent,
    TreeCardComponent,
    MatProgressSpinnerModule
  ]
})
export class SharedModule { }
