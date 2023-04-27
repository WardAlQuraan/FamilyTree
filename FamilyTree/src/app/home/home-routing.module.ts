import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { FamiliesComponent } from './families/families.component';
import { TreeComponent } from './tree/tree.component';

const routes: Routes = [
  {
    path:"",
    component:LandingComponent
  },
  {
    path:"clans",
    component:FamiliesComponent
  },{
    path:"tree/:id",
    component:TreeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
