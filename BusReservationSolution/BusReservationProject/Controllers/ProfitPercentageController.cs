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
    public class ProfitPercentageController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Get Profit Percentage
        [HttpGet]
        public List<proc_ProfitPercentage_Result> ProfitPercentage()
        {
            db.proc_ProfitPercentage();
            List<proc_ProfitPercentage_Result> profit = new List<proc_ProfitPercentage_Result>();
            foreach (var item in db.proc_ProfitPercentage())
            {
                profit.Add(item);
            }
            return profit;
        }

        //// GET: api/ProfitPercentage
        //public IQueryable<Ticket> GetTickets()
        //{
        //    return db.Tickets;
        //}

        //// GET: api/ProfitPercentage/5
        //[ResponseType(typeof(Ticket))]
        //public IHttpActionResult GetTicket(int id)
        //{
        //    Ticket ticket = db.Tickets.Find(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(ticket);
        //}

        //// PUT: api/ProfitPercentage/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutTicket(int id, Ticket ticket)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != ticket.TicketID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(ticket).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TicketExists(id))
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

        //// POST: api/ProfitPercentage
        //[ResponseType(typeof(Ticket))]
        //public IHttpActionResult PostTicket(Ticket ticket)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tickets.Add(ticket);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = ticket.TicketID }, ticket);
        //}

        //// DELETE: api/ProfitPercentage/5
        //[ResponseType(typeof(Ticket))]
        //public IHttpActionResult DeleteTicket(int id)
        //{
        //    Ticket ticket = db.Tickets.Find(id);
        //    if (ticket == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Tickets.Remove(ticket);
        //    db.SaveChanges();

        //    return Ok(ticket);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TicketExists(int id)
        {
            return db.Tickets.Count(e => e.TicketID == id) > 0;
        }
    }
}