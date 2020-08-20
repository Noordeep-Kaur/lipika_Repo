import { Component, OnInit } from '@angular/core';
import { DriverAdd } from '../models/driveradd';
import { UpdateDriverService } from '../Services/updatedriverservice';
import { FormsModule, FormGroup, Validators, FormControl, FormControlName} from '@angular/forms';

@Component({
  selector: 'app-updatedriver',
  templateUrl: './updatedriver.component.html',
  styleUrls: ['./updatedriver.component.css']
})
export class UpdatedriverComponent implements OnInit {

  model: any = {};
  drivers
  driver: DriverAdd;
  result;
  displaydriver;
  myDriverForm:FormGroup;

  constructor(private updateDriverService: UpdateDriverService) { 
    this.driver = new DriverAdd();
    this.myDriverForm = new FormGroup({
      driverid: new FormControl(null,Validators.required),
      firstname: new FormControl(null,Validators.required),
      lastname: new FormControl(null,Validators.required),
      phonenumber: new FormControl(null,Validators.required),
    });
   }
   public get driverid(){
    return this.myDriverForm.get("driverid");
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

  fetchDrivers()
  {
    this.updateDriverService.displayDriver().subscribe((data) => { 
      //console.log(data);
      this.displaydriver = data;
      console.log(this.displaydriver);
    })
  }
  editDriver(){
    this.updateDriverService.updateDriver(this.model).subscribe((data) => {
      console.log(data);
      this.result = data;
    })
      //console.log(this.model)
  }

  ngOnInit(): void {
  }

}
