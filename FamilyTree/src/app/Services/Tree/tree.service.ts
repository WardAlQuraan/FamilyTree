import { Injectable } from '@angular/core';
import { BaseService } from '../Base/base.service';
import { Tree } from 'src/app/Models/Tree/Tree';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TreeService extends BaseService<Tree> {

  constructor(private httpClient:HttpClient) {
    super(httpClient,"Tree")
   }

   GetFirstFamily(familyId:number):Observable<Tree>{
    return this.http.get<Tree>(this.baseUrl+"GetFirstFamily/"+familyId);
  }
}
