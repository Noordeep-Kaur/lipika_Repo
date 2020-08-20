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
    public class FeedbackController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Add Feeback
        [ResponseType(typeof(Feedback))]
        [HttpPost]
        public object EnterFeedback(Feedback feedback)
        {
            int count = db.Feedbacks.ToList().Count();
            if (count == 1)
            {
                db.proc_Feedback(feedback.PNR, feedback.JourneyRatings, feedback.Comments);
                db.SaveChanges();
                return "Feedback Entered"; 
            }
            else
            {
                return "Not Entered";
            }
        }

        //// GET: api/Feedback
        //public IQueryable<Feedback> GetFeedbacks()
        //{
        //    return db.Feedbacks;
        //}

        //// GET: api/Feedback/5
        //[ResponseType(typeof(Feedback))]
        //public IHttpActionResult GetFeedback(int id)
        //{
        //    Feedback feedback = db.Feedbacks.Find(id);
        //    if (feedback == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(feedback);
        //}

        //// PUT: api/Feedback/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutFeedback(int id, Feedback feedback)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != feedback.PNR)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(feedback).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FeedbackExists(id))
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

        //// POST: api/Feedback
        //[ResponseType(typeof(Feedback))]
        //public IHttpActionResult PostFeedback(Feedback feedback)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Feedbacks.Add(feedback);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (FeedbackExists(feedback.PNR))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
    }
}