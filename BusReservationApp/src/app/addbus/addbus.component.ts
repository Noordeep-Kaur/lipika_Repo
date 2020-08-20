import { Component, OnInit } from '@angular/core';
import { AddBus } from '../models/addbus';
import { AddBusService } from '../Services/addbusservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
selector: 'app-addbus',
templateUrl: './addbus.component.html',
styleUrls: ['./addbus.component.css']
})
export class AddbusComponent implements OnInit {

  buses;
  result;
  bus: AddBus;
  
  myBusForm:FormGroup;
  welcome:boolean;

  constructor(private addBusService: AddBusService) {
    this.bus = new AddBus();
    this.buses = [];

    this.myBusForm = new FormGroup({
      busnumber: new FormControl(null,Validators.required),
      driverid: new FormControl(null,Validators.required),
      driverphone: new FormControl(null,Validators.required),
      bustype: new FormControl(null,Validators.required),
      noofseats: new FormControl(null,Validators.required),
      busavailability: new FormControl(null,Validators.required)
    });
    this.welcome=false;
   }
   public get busnumber(){
     return this.myBusForm.get("busnumber");
  }
   public get driverid(){
     return this.myBusForm.get("driverid");
   }
   public get driverphone(){
    return this.myBusForm.get("driverphone");
  }
  public get bustype(){
    return this.myBusForm.get("bustype");
  }
  public get noofseats(){
    return this.myBusForm.get("noofseats");
  }
  public get busavailability(){
    return this.myBusForm.get("busavailability");
  }

  Register(){
  this.addBusService.addBus(this.bus).subscribe((data) => {
    this.result = data;
   })
  }
  
  ngOnInit(): void {
  }

}
