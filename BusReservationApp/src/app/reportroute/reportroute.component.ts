import { Component, OnInit } from '@angular/core';
import { Report } from '../models/report';
import { ReportService } from '../Services/reportsservice';

@Component({
  selector: 'app-reportroute',
  templateUrl: './reportroute.component.html',
  styleUrls: ['./reportroute.component.css']
})
export class ReportrouteComponent implements OnInit {

  result; 

  constructor(private reportService: ReportService) { }

  fetchRoutes()
  {
    this.reportService.getPreferredRoutes().subscribe((data) => { 
      console.log(data);
      this.result = data;
      console.log(this.result);
    })
  }

  ngOnInit(): void {
  }

}
