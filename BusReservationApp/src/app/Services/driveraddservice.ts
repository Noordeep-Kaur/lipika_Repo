import { DriverAdd } from '../models/driveradd';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";


@Injectable()
export class DriverAddService{

    driver;
    drivers: DriverAdd[];
    constructor(private http:HttpClient){
        this.drivers=[];
    }
    public addDriver(driver){
        console.log(driver);
        return this.http.post("http://localhost:51455/api/Driver",driver);
    }
}