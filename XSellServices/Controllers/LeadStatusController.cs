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
    public class LeadStatusController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/LeadStatus
        public IQueryable<LeadStatus> GetLeadStatus()
        {
            return db.LeadStatus;
        }

        // GET: api/LeadStatus/5
        [ResponseType(typeof(LeadStatus))]
        public IHttpActionResult GetLeadStatus(int id)
        {
            LeadStatus leadStatus = db.LeadStatus.Find(id);
            if (leadStatus == null)
            {
                return NotFound();
            }

            return Ok(leadStatus);
        }

        // PUT: api/LeadStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeadStatus(int id, LeadStatus leadStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leadStatus.LeadStatusID)
            {
                return BadRequest();
            }

            db.Entry(leadStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadStatusExists(id))
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

        // POST: api/LeadStatus
        [ResponseType(typeof(LeadStatus))]
        public IHttpActionResult PostLeadStatus(LeadStatus leadStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeadStatus.Add(leadStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leadStatus.LeadStatusID }, leadStatus);
        }

        // DELETE: api/LeadStatus/5
        [ResponseType(typeof(LeadStatus))]
        public IHttpActionResult DeleteLeadStatus(int id)
        {
            LeadStatus leadStatus = db.LeadStatus.Find(id);
            if (leadStatus == null)
            {
                return NotFound();
            }

            db.LeadStatus.Remove(leadStatus);
            db.SaveChanges();

            return Ok(leadStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeadStatusExists(int id)
        {
            return db.LeadStatus.Count(e => e.LeadStatusID == id) > 0;
        }
    }
}