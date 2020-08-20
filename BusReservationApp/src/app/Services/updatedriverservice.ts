import { DriverAdd } from '../models/driveradd';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class UpdateDriverService{

    model;
    //drivers: DriverAdd[];
    constructor(private http:HttpClient){
        //this.drivers=[];
    }
    public displayDriver(){
        return this.http.get("http://localhost:51455/api/Driver");
    }
    public updateDriver(model){
        return this.http.post("http://localhost:51455/api/UpdateDriverDetails",model);
    }
}