import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginInfo } from 'src/app/Models/User/LoginInfo';
import { TreeClaims} from 'src/app/Models/User/TreeClaims';
import { BaseService } from '../Base/base.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService<LoginInfo>{

  constructor(httpClient:HttpClient) {
    super(httpClient,"User")
  }

  Login(loginInfo:LoginInfo):Observable<TreeClaims>{
    return this.http.post<TreeClaims>(this.baseUrl+"login",loginInfo);
  }


}
