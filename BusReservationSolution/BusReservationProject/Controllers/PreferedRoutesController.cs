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
    public class PreferedRoutesController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Get Most Perferrable Routes
        [HttpGet]
        public List<proc_MostPreferedRoutes_Result> MostPreferedRoutes()
        {
            db.proc_MostPreferedRoutes();
            List<proc_MostPreferedRoutes_Result> routes = new List<proc_MostPreferedRoutes_Result>();
            foreach (var item in db.proc_MostPreferedRoutes())
            {
                routes.Add(item);
            }
            return routes;
        }

        //// GET: api/PreferedRoutes
        //public IQueryable<JourneyRoute> GetJourneyRoutes()
        //{
        //    return db.JourneyRoutes;
        //}

        //// GET: api/PreferedRoutes/5
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

        //// PUT: api/PreferedRoutes/5
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

        //// POST: api/PreferedRoutes
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

        //// DELETE: api/PreferedRoutes/5
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