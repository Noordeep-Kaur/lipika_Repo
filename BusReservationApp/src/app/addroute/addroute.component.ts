import { Component, OnInit } from '@angular/core';
import { AddRoute } from '../models/addroute';
import { AddRouteService } from '../Services/addrouteservice';
import { FormsModule, FormGroup, Validators, FormControl} from '@angular/forms';

@Component({
  selector: 'app-addroute',
  templateUrl: './addroute.component.html',
  styleUrls: ['./addroute.component.css']
})
export class AddrouteComponent implements OnInit {

  routes;
  result;
  route: AddRoute;
  
  myRouteForm:FormGroup;
  welcome:boolean;

  constructor(private addRouteService: AddRouteService) {
    this.route = new AddRoute();
    this.routes = [];

    this.myRouteForm = new FormGroup({
      tripid: new FormControl(null,Validators.required),
      fromlocation: new FormControl(null,Validators.required),
      tolocation: new FormControl(null,Validators.required),
      fromdate: new FormControl(null,Validators.required),
      todate: new FormControl(null,Validators.required),
      fromtime: new FormControl(null,Validators.required),
      totime: new FormControl(null,Validators.required),
      fromdescription: new FormControl(null,Validators.required),
      todescription: new FormControl(null,Validators.required),
      fare: new FormControl(null,Validators.required),
      noofseats: new FormControl(null,Validators.required)
    });
    this.welcome=false;
   }
   public get tripid(){
     return this.myRouteForm.get("tripid");
  }
   public get fromlocation(){
     return this.myRouteForm.get("fromlocation");
   }
   public get tolocation(){
    return this.myRouteForm.get("tolocation");
  }
  public get fromdate(){
    return this.myRouteForm.get("fromdate");
  }
  public get todate(){
    return this.myRouteForm.get("todate");
  }
  public get fromtime(){
    return this.myRouteForm.get("fromtime");
  }
  public get totime(){
    return this.myRouteForm.get("totime");
  }
  public get fromdescription(){
    return this.myRouteForm.get("fromdescription");
  }
  public get todescription(){
    return this.myRouteForm.get("todescription");
  }
  public get fare(){
    return this.myRouteForm.get("fare");
  }
  public get noofseats(){
    return this.myRouteForm.get("noofseats");
  }

  Register(){
    this.addRouteService.addRoute(this.route).subscribe((data) => {
     this.result = data;
    })
   }

  ngOnInit(): void {
  }

}
