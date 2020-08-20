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
    public class DriverController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Add Driver
        [ResponseType(typeof(DriverDetail))]
        [HttpPost]
        public object AddDriver(DriverDetail driverDetail)
        {
            int count = db.DriverDetails.ToList().Where(driver => driver.DID == driverDetail.DID).Count();
            if (count == 1)
            {
                return "This Driver Already Exists";
            }
            else
            {
                db.proc_AddDriver(driverDetail.FirstName, driverDetail.LastName, driverDetail.PhoneNumber);
                db.SaveChanges();
                return "Driver Registered Successfully";
            }
        }

        //Get All Driver Details for Update
        [HttpGet]
        public List<proc_DriverDetails_Result> GetAllDrivers()
        {
            db.proc_DriverDetails();
            List<proc_DriverDetails_Result> driver = new List<proc_DriverDetails_Result>();
            foreach (var item in db.proc_DriverDetails())
            {
                driver.Add(item);
            }
            return driver;
        }

        //// GET: api/Driver
        //public IQueryable<DriverDetail> GetDriverDetails()
        //{
        //    return db.DriverDetails;
        //}

        //// GET: api/Driver/5
        //[ResponseType(typeof(DriverDetail))]
        //public IHttpActionResult GetDriverDetail(int id)
        //{
        //    DriverDetail driverDetail = db.DriverDetails.Find(id);
        //    if (driverDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(driverDetail);
        //}

        //// PUT: api/Driver/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDriverDetail(int id, DriverDetail driverDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != driverDetail.DID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(driverDetail).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DriverDetailExists(id))
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

        //// POST: api/Driver
        //[ResponseType(typeof(DriverDetail))]
        //public IHttpActionResult PostDriverDetail(DriverDetail driverDetail)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.DriverDetails.Add(driverDetail);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = driverDetail.DID }, driverDetail);
        //}

        //// DELETE: api/Driver/5
        //[ResponseType(typeof(DriverDetail))]
        //public IHttpActionResult DeleteDriverDetail(int id)
        //{
        //    DriverDetail driverDetail = db.DriverDetails.Find(id);
        //    if (driverDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    db.DriverDetails.Remove(driverDetail);
        //    db.SaveChanges();

        //    return Ok(driverDetail);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverDetailExists(int id)
        {
            return db.DriverDetails.Count(e => e.DID == id) > 0;
        }
    }
}