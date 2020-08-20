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
    public class RouteController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Add Route
        [ResponseType(typeof(JourneyRoute))]
        [HttpPost]
        public object AddRoute(JourneyRoute journeyRoute)
        {
            int count = db.JourneyRoutes.ToList().Where(route => route.RouteID == journeyRoute.RouteID).Count();
            if (count == 1)
            {
                return "This Route Already Exists";
            }
            else
            {
                db.proc_AddRoute(journeyRoute.TripID, journeyRoute.FromLocation, journeyRoute.ToLocation, journeyRoute.FromDate, journeyRoute.ToDate, journeyRoute.FromTime, journeyRoute.ToTime, journeyRoute.FromDescription, journeyRoute.ToDescription, journeyRoute.Fare, journeyRoute.NumberOfSeats);
                db.SaveChanges();
                return "Route Added Successfully";
            }
        }

        //// GET: api/Route
        //public IQueryable<JourneyRoute> GetJourneyRoutes()
        //{
        //    return db.JourneyRoutes;
        //}

        //// GET: api/Route/5
        //[ResponseType(typeof(JourneyRoute))]
        //public IHttpActionResult GetJourneyRoute(int id)
        //{
        //    JourneyRoute journeyRoute = db.JourneyRoutes.Find(id);
        //    if (journeyRoute == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(journeyRoute);
        //}

        //// PUT: api/Route/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutJourneyRoute(int id, JourneyRoute journeyRoute)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != journeyRoute.RouteID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(journeyRoute).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JourneyRouteExists(id))
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

        //// POST: api/Route
        //[ResponseType(typeof(JourneyRoute))]
        //public IHttpActionResult PostJourneyRoute(JourneyRoute journeyRoute)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.JourneyRoutes.Add(journeyRoute);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = journeyRoute.RouteID }, journeyRoute);
        //}

        //// DELETE: api/Route/5
        //[ResponseType(typeof(JourneyRoute))]
        //public IHttpActionResult DeleteJourneyRoute(int id)
        //{
        //    JourneyRoute journeyRoute = db.JourneyRoutes.Find(id);
        //    if (journeyRoute == null)
        //    {
        //        return NotFound();
        //    }

        //    db.JourneyRoutes.Remove(journeyRoute);
        //    db.SaveChanges();

        //    return Ok(journeyRoute);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JourneyRouteExists(int id)
        {
            return db.JourneyRoutes.Count(e => e.RouteID == id) > 0;
        }
    }
}