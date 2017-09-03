using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using XSell.Models;
using XSellServices.Models;

namespace XSellServices.Controllers
{
    public class InsurerController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/Insurer
        public IQueryable<Insurer> GetInsurers()
        {
            //return db.Insurers.Include(n => n.Leads);
            return db.Insurers;
        }

        // GET: api/Insurer/5
        [ResponseType(typeof(Insurer))]
        public IHttpActionResult GetInsurer(int id)
        {
            Insurer insurer = db.Insurers.Find(id);
            if (insurer == null)
            {
                return NotFound();
            }

            return Ok(insurer);
        }

        // PUT: api/Insurer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurer(int id, Insurer insurer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurer.InsurerID)
            {
                return BadRequest();
            }

            db.Entry(insurer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsurerExists(id))
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

        // POST: api/Insurer
        [ResponseType(typeof(Insurer))]
        public IHttpActionResult PostInsurer(Insurer insurer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurers.Add(insurer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = insurer.InsurerID }, insurer);
        }

        // DELETE: api/Insurer/5
        [ResponseType(typeof(Insurer))]
        public IHttpActionResult DeleteInsurer(int id)
        {
            Insurer insurer = db.Insurers.Find(id);
            if (insurer == null)
            {
                return NotFound();
            }

            db.Insurers.Remove(insurer);
            db.SaveChanges();

            return Ok(insurer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsurerExists(int id)
        {
            return db.Insurers.Count(e => e.InsurerID == id) > 0;
        }
    }
}