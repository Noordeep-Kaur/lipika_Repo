import { Component, OnInit } from '@angular/core';
import { AdminLogin } from '../models/admin';
import { AdminLoginService  } from '../Services/adminloginservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { RouterModule, Router } from '@angular/router';
import { MyserviceService } from './../myservice.service';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  styleUrls: ['./adminlogin.component.css'],
  providers: [MyserviceService]
})
export class AdminloginComponent implements OnInit {

  username;
  password;
  admin: AdminLogin;
  myLoginForm: FormGroup;
  welcome: boolean;
  logins;
  result;

  constructor(private adminLoginService: AdminLoginService, private routes: Router, private service: MyserviceService) {
    this.admin = new AdminLogin();
    this.logins = [];

    this.myLoginForm = new FormGroup({
      uname: new FormControl(null,Validators.required),
      pass: new FormControl(null,Validators.required),
    });
    this.welcome=false;
   }
   public get uname(){
     return this.myLoginForm.get("uname");
   }
   public get pass(){
     return this.myLoginForm.get("pass");
   }

  Login(){
     
    console.log(this.admin.password);
    this.adminLoginService.adminLogin(this.admin).subscribe((data) => {
      this.result = data;
      this.result = "Welocme user you have successfully logged in..!!";
      this.admin = new AdminLogin()
      localStorage.setItem('username','Lipika');
      this.routes.navigate(['./home']);
    })
    //this.result = "Incorrect Username or Password";
   }
   
  ngOnInit(): void {
  }

}
