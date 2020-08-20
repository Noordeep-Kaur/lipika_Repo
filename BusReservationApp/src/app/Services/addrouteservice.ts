import { AddRoute } from '../models/addroute';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";


@Injectable()
export class AddRouteService{

    route;
    routes: AddRoute[];
    constructor(private http:HttpClient){
        this.routes=[];
    }
    public addRoute(routes){
        console.log(routes);
        return this.http.post("http://localhost:51455/api/Route",routes);
    }
}