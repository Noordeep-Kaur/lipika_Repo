import { AddTrip } from '../models/addtrip';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";


@Injectable()
export class AddTripService{

    trip;
    trips: AddTrip[];
    constructor(private http:HttpClient){
        this.trips=[];
    }
    public addDriver(trips){
        console.log(trips);
        return this.http.post("http://localhost:51455/api/Trip",trips);
    }
}