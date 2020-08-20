import { Component, OnInit } from '@angular/core';
import { Report } from '../models/report';
import { ReportService } from '../Services/reportsservice';

@Component({
  selector: 'app-reportcustomerreservation',
  templateUrl: './reportcustomerreservation.component.html',
  styleUrls: ['./reportcustomerreservation.component.css']
})
export class ReportcustomerreservationComponent implements OnInit {

  result; 

  constructor(private reportService: ReportService) { }

  fetchCustomerReservation()
  {
    this.reportService.getCustomerReservations().subscribe((data) => { 
      console.log(data);
      this.result = data;
      console.log(this.result);
    })
  }

  ngOnInit(): void {
  }

}
