import { AddBus } from '../models/addbus';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class UpdateBusService{

    model;
    //bus: AddBus[];
    constructor(private http:HttpClient){
        //this.buses=[];
    }
    public displayBus(){
        return this.http.get("http://localhost:51455/api/Bus");
    }
    public updateBus(model){
        return this.http.post("http://localhost:51455/api/UpdateBusDetails",model);
    }
}