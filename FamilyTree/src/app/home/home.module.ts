import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { LandingComponent } from './landing/landing.component';
import { SharedModule } from '../shared/shared.module';
import { FamiliesComponent } from './families/families.component';
import { TreeComponent } from './tree/tree.component';


@NgModule({
  declarations: [
    LandingComponent,
    FamiliesComponent,
    TreeComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule
  ]
})
export class HomeModule { }
