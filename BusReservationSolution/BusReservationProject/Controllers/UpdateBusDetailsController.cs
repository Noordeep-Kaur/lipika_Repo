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
    public class UpdateBusDetailsController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Update Bus
        [ResponseType(typeof(BusDetail))]
        [HttpPost]
        public IHttpActionResult UpdateBus(int id, BusDetail changedetail)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid Model");
            using (var bus = new BusReservationEntities1())
            {
                var existingbus = bus.BusDetails.Where(p => p.BusID == changedetail.BusID).FirstOrDefault<BusDetail>();
                if (existingbus != null)
                {
                    existingbus.BusNumber = changedetail.BusNumber;

                    existingbus.DriverID = changedetail.DriverID;

                    existingbus.DriverPhone = changedetail.DriverPhone;

                    existingbus.BusType = changedetail.BusType;

                    existingbus.NumberOfSeats = changedetail.NumberOfSeats;

                    existingbus.BusAvailability = changedetail.BusAvailability;

                    bus.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }

        //// GET: api/UpdateBusDetails
        //public IQueryable<BusDetail> GetBusDetails()
        //{
        //    return db.BusDetails;
        //}

        //// GET: api/UpdateBusDetails/5
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

        //// PUT: api/UpdateBusDetails/5
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

        //// POST: api/UpdateBusDetails
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

        //// DELETE: api/UpdateBusDetails/5
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