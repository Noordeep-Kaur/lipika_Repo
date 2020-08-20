using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Security;
using BusReservationProject.Models;

namespace BusReservationProject.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        //private BusReservationEntities1 db = new BusReservationEntities1();

        ////Get All Admin Details
        //[HttpGet]
        //public List<proc_AdminLogin_Result> GetAllAdmins()
        //{
        //    db.proc_AdminLogin();
        //    List<proc_AdminLogin_Result> login = new List<proc_AdminLogin_Result>();
        //    foreach (var admin in db.proc_AdminLogin())
        //    {
        //        login.Add(admin);
        //    }
        //    return login;
        //}

        ////AdminLogin
        //[ResponseType(typeof(Admin))]
        //[HttpPost]
        //public IHttpActionResult GetAdmin(proc_AdminLogin_Result admin)
        //{
        //    string result = null;
        //    List<proc_AdminLogin_Result> login = new List<proc_AdminLogin_Result>();
        //    foreach (var item in db.proc_AdminLogin())
        //    {
        //        login.Add(item);
        //    }
        //    foreach (var item in login)
        //    {
        //        if (item.username == admin.username && item.password == admin.password)
        //        {
        //            FormsAuthentication.SetAuthCookie(item.username, false);
        //            result = "Logged in";
        //        }
        //    }
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        ////Add Bus
        //[ResponseType(typeof(BusDetail))]
        //[HttpPost]
        //public object AddBus(BusDetail busDetail)
        //{
        //    int count = db.BusDetails.ToList().Where(bus => bus.BusID == busDetail.BusID).Count();
        //    if (count == 1)
        //    {
        //        return "This Bus Already Exists";
        //    }
        //    else
        //    {
        //        db.proc_AddBus(busDetail.BusNumber, busDetail.DriverID, busDetail.DriverPhone, busDetail.BusType, busDetail.NumberOfSeats, busDetail.BusAvailability);
        //        db.SaveChanges();
        //        return "Bus Registered Successfully";
        //    }
        //}

        ////Add Driver
        //[ResponseType(typeof(DriverDetail))]
        //[HttpPost]
        //public object AddDriver(DriverDetail driverDetail)
        //{
        //    int count = db.DriverDetails.ToList().Where(driver => driver.DID == driverDetail.DID).Count();
        //    if (count == 1)
        //    {
        //        return "This Driver Already Exists";
        //    }
        //    else
        //    {
        //        db.proc_AddDriver(driverDetail.FirstName, driverDetail.LastName, driverDetail.PhoneNumber);
        //        db.SaveChanges();
        //        return "Driver Registered Successfully";
        //    }
        //}

        ////Add Trip
        //[ResponseType(typeof(Trip))]
        //[HttpPost]
        //public object AddTrip(Trip trip)
        //{
        //    int count = db.Trips.ToList().Where(trips => trips.TID == trip.TID).Count();
        //    if (count == 1)
        //    {
        //        return "This Trip Already Exists";
        //    }
        //    else
        //    {
        //        db.proc_AddTrip(trip.BusID, trip.FromLocation, trip.ToLocation);
        //        db.SaveChanges();
        //        return "Trip Added Successfully";
        //    }
        //}

        ////Add Route
        //[ResponseType(typeof(JourneyRoute))]
        //[HttpPost]
        //public object AddRoute(JourneyRoute journeyRoute)
        //{
        //    int count = db.JourneyRoutes.ToList().Where(route => route.RouteID == journeyRoute.RouteID).Count();
        //    if (count == 1)
        //    {
        //        return "This Route Already Exists";
        //    }
        //    else
        //    {
        //        db.proc_AddRoute(journeyRoute.TripID, journeyRoute.FromLocation, journeyRoute.ToLocation, journeyRoute.FromDate, journeyRoute.ToDate, journeyRoute.FromTime, journeyRoute.ToTime, journeyRoute.FromDescription, journeyRoute.ToDescription, journeyRoute.Fare, journeyRoute.NumberOfSeats);
        //        db.SaveChanges();
        //        return "Route Added Successfully";
        //    }
        //}

        ////Update Bus
        //[ResponseType(typeof(BusDetail))]
        //[HttpPut]
        //public IHttpActionResult UpdateBus(int id, BusDetail changedetail)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid Model");
        //    using (var bus = new BusReservationEntities1())
        //    {
        //        var existingbus = bus.BusDetails.Where(p => p.BusID == changedetail.BusID).FirstOrDefault<BusDetail>();
        //        if (existingbus != null)
        //        {
        //            existingbus.BusNumber = changedetail.BusNumber;

        //            existingbus.DriverID = changedetail.DriverID;

        //            existingbus.DriverPhone = changedetail.DriverPhone;

        //            existingbus.BusType = changedetail.BusType;

        //            existingbus.NumberOfSeats = changedetail.NumberOfSeats;

        //            existingbus.BusAvailability = changedetail.BusAvailability;

        //            bus.SaveChanges();
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    return Ok();
        //}

        ////Update Driver
        //[ResponseType(typeof(DriverDetail))]
        //[HttpPost]
        //public IHttpActionResult UpdateDriver(DriverDetail changedetail)
        //{
        //    var driver = new BusReservationEntities1();
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return BadRequest("Not a valid Model");
        //        {
        //            var existingdriver = driver.DriverDetails.Where(p => p.DID == changedetail.DID).FirstOrDefault<DriverDetail>();
        //            if (existingdriver != null)
        //            {
        //                existingdriver.DID = changedetail.DID;

        //                existingdriver.FirstName = changedetail.FirstName;

        //                existingdriver.LastName = changedetail.LastName;

        //                existingdriver.PhoneNumber = changedetail.PhoneNumber;

        //                driver.SaveChanges();
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        var error = driver.GetValidationErrors();
        //        return NotFound();
        //    }

        //}

        //////Get All Bus Details for Update
        //[HttpGet]
        //public List<proc_BusDetails_Result> GetAllBuses()
        //{
        //    db.proc_BusDetails();
        //    List<proc_BusDetails_Result> bus = new List<proc_BusDetails_Result>();
        //    foreach (var item in db.proc_BusDetails())
        //    {
        //        bus.Add(item);
        //    }
        //    return bus;
        //}

        ////Get All Driver Details for Update
        //[HttpGet]
        //public List<proc_DriverDetails_Result> GetAllDrivers()
        //{
        //    db.proc_DriverDetails();
        //    List<proc_DriverDetails_Result> driver = new List<proc_DriverDetails_Result>();
        //    foreach (var item in db.proc_DriverDetails())
        //    {
        //        driver.Add(item);
        //    }
        //    return driver;
        //}

        ////Print Ticket
        ////[ResponseType(typeof(Ticket))]
        //[HttpPost]
        //public object TicketPrint(Ticket ticket)
        //{
        //    var count = db.proc_TicketDetails(ticket.BookingUserID);
        //    return count;
        //    //if (count > 0)
        //    //{
        //    //    db.proc_TicketDetails(ticket.BookingUserID);
        //    //    db.SaveChanges();
        //    //    return "Cuurrent Booking";
        //    //}
        //    //else
        //    //{
        //    //    return "The User Does Not Have Current Booking";
        //    //}
        //}

        //////Get Most Perferrable Bus Type
        //[HttpGet]
        //public List<proc_MostPreferedBusType_Result> MostPreferedBusType()
        //{
        //    db.proc_MostPreferedBusType();
        //    List<proc_MostPreferedBusType_Result> busType = new List<proc_MostPreferedBusType_Result>();
        //    foreach (var item in db.proc_MostPreferedBusType())
        //    {
        //        busType.Add(item);
        //    }
        //    return busType;
        //}

        ////Get Most Perferrable Routes
        //[HttpGet]
        //public List<proc_MostPreferedRoutes_Result> MostPreferedRoutes()
        //{
        //    db.proc_MostPreferedRoutes();
        //    List<proc_MostPreferedRoutes_Result> routes = new List<proc_MostPreferedRoutes_Result>();
        //    foreach (var item in db.proc_MostPreferedRoutes())
        //    {
        //        routes.Add(item);
        //    }
        //    return routes;
        //}

        ////Get Profit Percentage
        //[HttpGet]
        //public List<proc_ProfitPercentage_Result> ProfitPercentage()
        //{
        //    db.proc_ProfitPercentage();
        //    List<proc_ProfitPercentage_Result> profit = new List<proc_ProfitPercentage_Result>();
        //    foreach (var item in db.proc_ProfitPercentage())
        //    {
        //        profit.Add(item);
        //    }
        //    return profit;
        //}

        ////Get Reservation Details of Customer 
        //[HttpGet]
        //public List<proc_ReservationDetailsofCustomer_Result> CustomerReservationDetails()
        //{
        //    db.proc_ReservationDetailsofCustomer();
        //    List<proc_ReservationDetailsofCustomer_Result> customerReservationDetails = new List<proc_ReservationDetailsofCustomer_Result>();
        //    foreach (var item in db.proc_ReservationDetailsofCustomer())
        //    {
        //        customerReservationDetails.Add(item);
        //    }
        //    return customerReservationDetails;
        //}

        // GET: api/Admin
        //public IQueryable<BusDetail> GetBusDetails()
        //{
        //    return db.BusDetails;
        //}

        //GET: api/Admin/5
        //[ResponseType(typeof(BusDetail))]
        //public IHttpActionResult GetBusDetail(int id)
        //{
        //    BusDetail busDetail = db.BusDetails.Find(id);
        //    if (busDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(busDetail);
        //}

        //[ResponseType(typeof(BusDetail))]
        //[HttpPut]
        //public object UpdateBus(BusDetail busDetail)
        //{
        //    int count = db.BusDetails.ToList().Where(bus => bus.BusID == busDetail.BusID).Count();
        //    if (count == 1)
        //    {
        //        db.proc_UpdateBus(busDetail.BusID, busDetail.BusNumber, busDetail.DriverID, busDetail.DriverPhone, busDetail.BusType, busDetail.NumberOfSeats, busDetail.BusAvailability);
        //        return "Bus Updated Successfully";

        //    }
        //    else
        //    {
        //        return "This Bus Does not Exists";
        //    }
        //}

        // PUT: api/Admin/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutBusDetail(int id, BusDetail busDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != busDetail.BusID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(busDetail).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BusDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Admin
        //[ResponseType(typeof(BusDetail))]
        //public IHttpActionResult PostBusDetail(BusDetail busDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.BusDetails.Add(busDetail);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = busDetail.BusID }, busDetail);
        //}

    //    // DELETE: api/Admin/5
    //    [ResponseType(typeof(BusDetail))]
    //    public IHttpActionResult DeleteBusDetail(int id)
    //    {
    //        BusDetail busDetail = db.BusDetails.Find(id);
    //        if (busDetail == null)
    //        {
    //            return NotFound();
    //        }

    //        db.BusDetails.Remove(busDetail);
    //        db.SaveChanges();

    //        return Ok(busDetail);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool BusDetailExists(int id)
    //    {
    //        return db.BusDetails.Count(e => e.BusID == id) > 0;
    //    }
    }
}