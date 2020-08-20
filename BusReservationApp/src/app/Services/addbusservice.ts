import { AddBus } from '../models/addbus';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class AddBusService{

    bus;
    buses: AddBus[];
    constructor(private http:HttpClient){
        this.buses=[];
    }
    public addBus(bus){
        console.log(bus);
        return this.http.post("http://localhost:51455/api/Bus",bus);
    }
}