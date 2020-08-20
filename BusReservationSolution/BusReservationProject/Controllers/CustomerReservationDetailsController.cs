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
    public class CustomerReservationDetailsController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Get Reservation Details of Customer 
        [HttpGet]
        public List<proc_ReservationDetailsofCustomer_Result> CustomerReservationDetails()
        {
            db.proc_ReservationDetailsofCustomer();
            List<proc_ReservationDetailsofCustomer_Result> customerReservationDetails = new List<proc_ReservationDetailsofCustomer_Result>();
            foreach (var item in db.proc_ReservationDetailsofCustomer())
            {
                customerReservationDetails.Add(item);
            }
            return customerReservationDetails;
        }

        //// GET: api/CustomerReservationDetails
        //public IQueryable<Ticket> GetTickets()
        //{
        //    return db.Tickets;
        //}

        //// GET: api/CustomerReservationDetails/5
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

        //// PUT: api/CustomerReservationDetails/5
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

        //// POST: api/CustomerReservationDetails
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

        //// DELETE: api/CustomerReservationDetails/5
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