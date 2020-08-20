import { AdminLogin } from '../models/admin';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Router } from '@angular/router';


@Injectable()
export class AdminLoginService{

    admin;
    admins: AdminLogin[];
    constructor(private http:HttpClient){
        this.admins=[];
    }
    public adminLogin(admin){
        console.log(admin);
        return this.http.post("http://localhost:51455/api/AdminLogin",admin);
    }
}