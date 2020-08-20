import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminloginComponent } from './adminlogin/adminlogin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { AddbusComponent } from './addbus/addbus.component';
import { UpdatebusComponent } from './updatebus/updatebus.component';
import { DriveraddComponent } from './driveradd/driveradd.component';
import { AddtripComponent } from './addtrip/addtrip.component';
import { AddrouteComponent } from './addroute/addroute.component';
import { AddBusService } from './Services/addbusservice';
import { DriverAddService } from './Services/driveraddservice'
import { AddTripService } from './Services/addtripservice';
import { AddRouteService } from './Services/addrouteservice';
import { AdminLoginService } from './Services/adminloginservice';
import { UpdateBusService } from './Services/updatebusservice';
import { UpdatedriverComponent } from './updatedriver/updatedriver.component';
import { UpdateDriverService } from './Services/updatedriverservice';
import { PrintticketComponent } from './printticket/printticket.component';
import { PrintTicketService } from './Services/printticketservice';
import { ReportService } from './Services/reportsservice';
import { ReportComponent } from './report/report.component';
import { ReportprofitComponent } from './reportprofit/reportprofit.component';
import { ReportbustypeComponent } from './reportbustype/reportbustype.component';
import { ReportrouteComponent } from './reportroute/reportroute.component';
import { ReportcustomerreservationComponent } from './reportcustomerreservation/reportcustomerreservation.component';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { BusdetailsComponent } from './busdetails/busdetails.component';
import { DriverdetailsComponent } from './driverdetails/driverdetails.component';
import { HomeComponent } from './home/home.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { FeedbackService } from './Services/feedbackservice';
import { CookieService } from 'ngx-cookie-service';
import { AuthGuard } from './auth.guard';

var myRoutes: Routes = [
  {path:"dashboard", component:AdmindashboardComponent},
              {path:"home", component:HomeComponent},
              {path:"adminlogin", component:AdminloginComponent},
              {path:"addbus", canActivate: [AuthGuard], component:AddbusComponent},
              {path:"driveradd", canActivate: [AuthGuard], component:DriveraddComponent},
              {path:"addtrip", canActivate: [AuthGuard], component:AddtripComponent},
              {path:"addroute", canActivate: [AuthGuard], component:AddrouteComponent},
              {path:"busdetails", canActivate: [AuthGuard], component:BusdetailsComponent,children:[
                {path:"bus", component:UpdatebusComponent}
              ]},
              {path:"driverdetails", canActivate: [AuthGuard], component:DriverdetailsComponent,children:[
                {path:"driver", component:UpdatedriverComponent}]},
              {path:"reports", canActivate: [AuthGuard], component:ReportComponent,children:[
                {path:"bustype", component:ReportbustypeComponent},
                {path:"route", component:ReportrouteComponent},
                {path:"profit", component:ReportprofitComponent},
                {path:"customer", component:ReportcustomerreservationComponent}
              ]}

]
@NgModule({
  declarations: [
    AppComponent,
    AdminloginComponent,
    DashboardComponent,
    AddbusComponent,
    UpdatebusComponent,
    DriveraddComponent,
    AddtripComponent,
    AddrouteComponent,
    UpdatedriverComponent,
    PrintticketComponent,
    ReportComponent,
    ReportprofitComponent,
    ReportbustypeComponent,
    ReportrouteComponent,
    ReportcustomerreservationComponent,
    AdmindashboardComponent,
    BusdetailsComponent,
    DriverdetailsComponent,
    HomeComponent,
    FeedbackComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(myRoutes),
  ],
  providers: [AddBusService, DriverAddService, AddTripService, AddRouteService, AdminLoginService, UpdateBusService, UpdateDriverService, PrintTicketService, ReportService, FeedbackService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
