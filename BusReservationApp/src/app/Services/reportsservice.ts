import { Report } from '../models/report';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class ReportService{

    constructor(private http:HttpClient){ }
    public getProfit(){
        return this.http.get("http://localhost:51455/api/ProfitPercentage");
    }
    public getPreferredRoutes(){
        return this.http.get("http://localhost:51455/api/PreferedRoutes");
    }
    public getPreferredBusType(){
        return this.http.get("http://localhost:51455/api/PreferedBusType");
    }
    public getCustomerReservations(){
        return this.http.get("http://localhost:51455/api/CustomerReservationDetails");
    }
}