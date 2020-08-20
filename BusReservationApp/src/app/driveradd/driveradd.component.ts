import { Component, OnInit } from '@angular/core';
import { DriverAdd } from '../models/driveradd';
import { DriverAddService } from '../Services/driveraddservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';

@Component({
  selector: 'app-driveradd',
  templateUrl: './driveradd.component.html',
  styleUrls: ['./driveradd.component.css']
})
export class DriveraddComponent implements OnInit {

  drivers;
  result;
  driver: DriverAdd;
  DriverAdd
  myDriverForm:FormGroup;
  welcome:boolean;

  constructor(private driverAddService: DriverAddService) {
    this.driver = new DriverAdd();
    this.drivers = [];

    this.myDriverForm = new FormGroup({
      firstname: new FormControl(null,Validators.required),
      lastname: new FormControl(null,Validators.required),
      phonenumber: new FormControl(null,Validators.required),
    });
    this.welcome=false;
   }
   public get firstname(){
     return this.myDriverForm.get("firstname");
   }
   public get lastname(){
     return this.myDriverForm.get("lastname");
   }
   public get phonenumber(){
    return this.myDriverForm.get("phonenumber");
   }

  Register(){
    this.driverAddService.addDriver(this.driver).subscribe((data) => {
      this.result = data;
    })
   }
  ngOnInit(): void {
  }

}