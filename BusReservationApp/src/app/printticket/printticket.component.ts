import { Component, OnInit } from '@angular/core';
import { PrintTicket } from '../models/printticket';
import { PrintTicketService } from '../Services/printticketservice';

@Component({
  selector: 'app-printticket',
  templateUrl: './printticket.component.html',
  styleUrls: ['./printticket.component.css']
})
export class PrintticketComponent implements OnInit {

  ticket: any = {};
  tickets;
  result;
  constructor(private printTicketService: PrintTicketService) { 
    //this.ticket = new PrintTicket();
    // this.tickets=[];
  }

  ticketDisplay(){
    this.printTicketService.displayTicket(this.ticket).subscribe((data) => {
      //console.log(data);
      this.result = data;
      console.log(this.result);
      //console.log(this.ticket);
    })
  }

  ngOnInit(): void {
  }

}
