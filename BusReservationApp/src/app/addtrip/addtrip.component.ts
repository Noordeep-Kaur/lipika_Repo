import { Component, OnInit } from '@angular/core';
import { AddTrip } from '../models/addtrip';
import { AddTripService } from '../Services/addtripservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';

@Component({
  selector: 'app-addtrip',
  templateUrl: './addtrip.component.html',
  styleUrls: ['./addtrip.component.css']
})
export class AddtripComponent implements OnInit {

  trips;
  result;
  trip: AddTrip;
  myTripForm:FormGroup;
  welcome:boolean;

  constructor(private addTripService: AddTripService) {
    this.trip = new AddTrip();
    this.trips = [];

    this.myTripForm = new FormGroup({
      busid: new FormControl(null,Validators.required),
      fromlocation: new FormControl(null,Validators.required),
      tolocation: new FormControl(null,Validators.required),
    });
    this.welcome=false;
   }
   public get busid(){
     return this.myTripForm.get("busid");
   }
   public get fromlocation(){
     return this.myTripForm.get("fromlocation");
   }
   public get tolocation(){
    return this.myTripForm.get("tolocation");
   }

  Register(){
    this.addTripService.addDriver(this.trip).subscribe((data) => {
      this.result = data;
    })
   }

  ngOnInit(): void {
  }

}
