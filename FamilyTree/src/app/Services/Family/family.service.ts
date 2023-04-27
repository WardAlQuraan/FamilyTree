import { Injectable } from '@angular/core';
import { BaseService } from '../Base/base.service';
import { Family } from 'src/app/Models/Family/Family';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class FamilyService extends BaseService<Family>{

  constructor(private httpClient:HttpClient) {
    super(httpClient,"Family");
   }
}
