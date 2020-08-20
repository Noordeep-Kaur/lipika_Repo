import { Component, OnInit } from '@angular/core';
import { Report } from '../models/report';
import { ReportService } from '../Services/reportsservice';

@Component({
  selector: 'app-reportbustype',
  templateUrl: './reportbustype.component.html',
  styleUrls: ['./reportbustype.component.css']
})
export class ReportbustypeComponent implements OnInit {

  result; 

  constructor(private reportService: ReportService) { }

  fetchBusType()
  {
    this.reportService.getPreferredBusType().subscribe((data) => { 
      console.log(data);
      this.result = data;
      console.log(this.result);
    })
  }

  ngOnInit(): void {
  }

}
