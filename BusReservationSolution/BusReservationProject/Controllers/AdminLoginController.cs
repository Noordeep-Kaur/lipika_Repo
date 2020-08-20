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
    public class AdminLoginController : ApiController
    {
        private BusReservationEntities1 db = new BusReservationEntities1();

        //Get All Admin Details
        [HttpGet]
        public List<proc_AdminLogin_Result> GetAllAdmins()
        {
            db.proc_AdminLogin();
            List<proc_AdminLogin_Result> login = new List<proc_AdminLogin_Result>();
            foreach (var admin in db.proc_AdminLogin())
            {
                login.Add(admin);
            }
            return login;
        }

        //AdminLogin
        [ResponseType(typeof(Admin))]
        [HttpPost]
        public IHttpActionResult GetAdmin(proc_AdminLogin_Result admin)
        {
            string result = null;
            List<proc_AdminLogin_Result> login = new List<proc_AdminLogin_Result>();
            foreach (var item in db.proc_AdminLogin())
            {
                login.Add(item);
            }
            foreach (var item in login)
            {
                if (item.username == admin.username && item.password == admin.password)
                {
                    FormsAuthentication.SetAuthCookie(item.username, false);
                    result = "Logged in";
                }
            }
            if (result == null)
            {
                return Ok("Fail");
            }
            return Ok(result);
        }

        //// GET: api/AdminLogin
        //public IQueryable<Admin> GetAdmins()
        //{
        //    return db.Admins;
        //}

        //// GET: api/AdminLogin/5
        //[ResponseType(typeof(Admin))]
        //public IHttpActionResult GetAdmin(int id)
        //{
        //    Admin admin = db.Admins.Find(id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(admin);
        //}

        // PUT: api/AdminLogin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdmin(int id, Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.ID)
            {
                return BadRequest();
            }

            db.Entry(admin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdminLogin
        //[ResponseType(typeof(Admin))]
        //public IHttpActionResult PostAdmin(Admin admin)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Admins.Add(admin);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AdminExists(admin.ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = admin.ID }, admin);
        //}

        // DELETE: api/AdminLogin/5
        [ResponseType(typeof(Admin))]
        public IHttpActionResult DeleteAdmin(int id)
        {
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return NotFound();
            }

            db.Admins.Remove(admin);
            db.SaveChanges();

            return Ok(admin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminExists(int id)
        {
            return db.Admins.Count(e => e.ID == id) > 0;
        }
    }
}