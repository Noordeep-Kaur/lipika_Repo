import { Component, OnInit } from '@angular/core';
import { Report } from '../models/report';
import { ReportService } from '../Services/reportsservice';

@Component({
  selector: 'app-reportprofit',
  templateUrl: './reportprofit.component.html',
  styleUrls: ['./reportprofit.component.css']
})
export class ReportprofitComponent implements OnInit {

  result; 

  constructor(private reportService: ReportService) { }

  fetchProfit()
  {
    this.reportService.getProfit().subscribe((data) => { 
      console.log(data);
      this.result = data;
      console.log(this.result);
    })
  }

  ngOnInit(): void {
  }

}
