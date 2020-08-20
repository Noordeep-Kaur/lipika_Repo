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
    public class UpdateDriverDetailsController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Update Driver
        [ResponseType(typeof(DriverDetail))]
        [HttpPost]
        public IHttpActionResult UpdateDriver(DriverDetail changedetail)
        {
            var driver = new BusReservationEntities1();
            string result = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Not a valid Model");
                {
                    var existingdriver = driver.DriverDetails.Where(p => p.DID == changedetail.DID).FirstOrDefault<DriverDetail>();
                    if (existingdriver != null)
                    {
                        existingdriver.DID = changedetail.DID;

                        existingdriver.FirstName = changedetail.FirstName;

                        existingdriver.LastName = changedetail.LastName;

                        existingdriver.PhoneNumber = changedetail.PhoneNumber;

                        driver.SaveChanges();
                    }
                    else
                    {
                        return Ok(result);
                    }
                }
                return Ok("Data Updated");
            }
            catch (Exception e)
            {
                var error = driver.GetValidationErrors();
                return Ok(result);
            }

        }

        //// GET: api/UpdateDriverDetails
        //public IQueryable<DriverDetail> GetDriverDetails()
        //{
        //    return db.DriverDetails;
        //}

        //// GET: api/UpdateDriverDetails/5
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

        //// PUT: api/UpdateDriverDetails/5
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

        //// POST: api/UpdateDriverDetails
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

        //// DELETE: api/UpdateDriverDetails/5
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