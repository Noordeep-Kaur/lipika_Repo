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
    public class TripController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Add Trip
        [ResponseType(typeof(Trip))]
        [HttpPost]
        public object AddTrip(Trip trip)
        {
            int count = db.Trips.ToList().Where(trips => trips.TID == trip.TID).Count();
            if (count == 1)
            {
                return "This Trip Already Exists";
            }
            else
            {
                db.proc_AddTrip(trip.BusID, trip.FromLocation, trip.ToLocation);
                db.SaveChanges();
                return "Trip Added Successfully";
            }
        }

        //// GET: api/Trip
        //public IQueryable<Trip> GetTrips()
        //{
        //    return db.Trips;
        //}

        //// GET: api/Trip/5
        //[ResponseType(typeof(Trip))]
        //public IHttpActionResult GetTrip(int id)
        //{
        //    Trip trip = db.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(trip);
        //}

        //// PUT: api/Trip/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTrip(int id, Trip trip)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != trip.TID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(trip).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TripExists(id))
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

        //// POST: api/Trip
        //[ResponseType(typeof(Trip))]
        //public IHttpActionResult PostTrip(Trip trip)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Trips.Add(trip);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = trip.TID }, trip);
        //}

        //// DELETE: api/Trip/5
        //[ResponseType(typeof(Trip))]
        //public IHttpActionResult DeleteTrip(int id)
        //{
        //    Trip trip = db.Trips.Find(id);
        //    if (trip == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Trips.Remove(trip);
        //    db.SaveChanges();

        //    return Ok(trip);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TripExists(int id)
        {
            return db.Trips.Count(e => e.TID == id) > 0;
        }
    }
}