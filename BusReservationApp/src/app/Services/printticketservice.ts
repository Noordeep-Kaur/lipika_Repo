import { PrintTicket } from '../models/printticket';
import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";

@Injectable()
export class PrintTicketService{

    //ticket: PrintTicket[];
    constructor(private http:HttpClient){
        //this.ticket=[];
    }
    public displayTicket(ticket: any){
        return this.http.post<any>("http://localhost:51455/api/Ticket",ticket);
    }
}