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
    public class ReasonController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/Reason
        public IQueryable<Reason> GetReasons()
        {
            return db.Reasons;
        }

        // GET: api/Reason/5
        [ResponseType(typeof(Reason))]
        public IHttpActionResult GetReason(int id)
        {
            Reason reason = db.Reasons.Find(id);
            if (reason == null)
            {
                return NotFound();
            }

            return Ok(reason);
        }

        // PUT: api/Reason/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReason(int id, Reason reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reason.ReasonID)
            {
                return BadRequest();
            }

            db.Entry(reason).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReasonExists(id))
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

        // POST: api/Reason
        [ResponseType(typeof(Reason))]
        public IHttpActionResult PostReason(Reason reason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reasons.Add(reason);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reason.ReasonID }, reason);
        }

        // DELETE: api/Reason/5
        [ResponseType(typeof(Reason))]
        public IHttpActionResult DeleteReason(int id)
        {
            Reason reason = db.Reasons.Find(id);
            if (reason == null)
            {
                return NotFound();
            }

            db.Reasons.Remove(reason);
            db.SaveChanges();

            return Ok(reason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReasonExists(int id)
        {
            return db.Reasons.Count(e => e.ReasonID == id) > 0;
        }
    }
}