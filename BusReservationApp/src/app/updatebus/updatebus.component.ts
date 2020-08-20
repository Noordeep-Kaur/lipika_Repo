import { Component, OnInit } from '@angular/core';
import { AddBus } from '../models/addbus';
import { UpdateBusService } from '../Services/updatebusservice';
import { FormsModule, FormGroup, Validators, FormControl, FormControlName} from '@angular/forms';

@Component({
  selector: 'app-updatebus',
  templateUrl: './updatebus.component.html',
  styleUrls: ['./updatebus.component.css']
})
export class UpdatebusComponent implements OnInit {

  //buses
  //bus: AddBus;
  model: any = {};
  displaybus;
  result;
  myBusForm:FormGroup;

  constructor(private updateBusService: UpdateBusService) { 
    //this.bus = new AddBus();
    this.myBusForm = new FormGroup({
      busid: new FormControl(null,Validators.required),
      busnumber: new FormControl(null,Validators.required),
      driverid: new FormControl(null,Validators.required),
      driverphone: new FormControl(null,Validators.required),
      bustype: new FormControl(null,Validators.required),
      noofseats: new FormControl(null,Validators.required),
      busavailability: new FormControl(null,Validators.required)
    });
   }
   public get busid(){
    return this.myBusForm.get("busid");
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

  fetchBuses()
  {
    this.updateBusService.displayBus().subscribe((data) => { 
      //console.log(data);
      this.displaybus = data;
      console.log(this.displaybus);
    })
  }
  editBus(){
    this.updateBusService.updateBus(this.model).subscribe((data) => {
      console.log(data);
      this.result = data;
    })
      //console.log(this.model)
  }

  ngOnInit(): void {
  }

}
