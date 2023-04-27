import { Component } from '@angular/core';
import { LoginInfo } from './Models/User/LoginInfo';
import { AuthService } from './Services/Auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FamilyTree';

  constructor(private authService:AuthService){
    var login :LoginInfo = {
      email : "Admin@tree.com", password:"12345678"
    }
    this.authService.Login(login).subscribe(data=>{
      localStorage.setItem('access-info', JSON.stringify(data));
    })
  }

}
