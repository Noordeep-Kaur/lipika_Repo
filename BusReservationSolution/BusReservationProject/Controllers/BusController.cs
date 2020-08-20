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
    public class BusController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Get All Bus Details for Update
        [HttpGet]
        public List<proc_BusDetails_Result> GetAllBuses()
        {
            db.proc_BusDetails();
            List<proc_BusDetails_Result> bus = new List<proc_BusDetails_Result>();
            foreach (var item in db.proc_BusDetails())
            {
                bus.Add(item);
            }
            return bus;
        }

        //Add Bus
        [ResponseType(typeof(BusDetail))]
        [HttpPost]
        public object AddBus(BusDetail busDetail)
        {
            int count = db.BusDetails.ToList().Where(bus => bus.BusID == busDetail.BusID).Count();
            if (count == 1)
            {
                return "This Bus Already Exists";
            }
            else
            {
                db.proc_AddBus(busDetail.BusNumber, busDetail.DriverID, busDetail.DriverPhone, busDetail.BusType, busDetail.NumberOfSeats, busDetail.BusAvailability);
                db.SaveChanges();
                return "Bus Registered Successfully";
            }
        }

        

        //// GET: api/Bus
        //public IQueryable<BusDetail> GetBusDetails()
        //{
        //    return db.BusDetails;
        //}

        //// GET: api/Bus/5
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

        //// PUT: api/Bus/5
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

        //// POST: api/Bus
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

        //// DELETE: api/Bus/5
        //[ResponseType(typeof(BusDetail))]
        //public IHttpActionResult DeleteBusDetail(int id)
        //{
        //    BusDetail busDetail = db.BusDetails.Find(id);
        //    if (busDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.BusDetails.Remove(busDetail);
        //    db.SaveChanges();

        //    return Ok(busDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusDetailExists(int id)
        {
            return db.BusDetails.Count(e => e.BusID == id) > 0;
        }
    }
}