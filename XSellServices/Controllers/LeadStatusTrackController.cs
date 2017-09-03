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
    public class LeadStatusTrackController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/LeadStatusTrack
        public IQueryable<LeadStatusTrack> GetLeadStatusTracks()
        {
            return db.LeadStatusTracks;
        }

        // GET: api/LeadStatusTrack/5
        [ResponseType(typeof(LeadStatusTrack))]
        public IHttpActionResult GetLeadStatusTrack(int id)
        {
            LeadStatusTrack leadStatusTrack = db.LeadStatusTracks.Find(id);
            if (leadStatusTrack == null)
            {
                return NotFound();
            }

            return Ok(leadStatusTrack);
        }

        // PUT: api/LeadStatusTrack/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeadStatusTrack(int id, LeadStatusTrack leadStatusTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leadStatusTrack.LeadStatusTrackID)
            {
                return BadRequest();
            }

            db.Entry(leadStatusTrack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadStatusTrackExists(id))
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

        // POST: api/LeadStatusTrack
        [ResponseType(typeof(LeadStatusTrack))]
        public IHttpActionResult PostLeadStatusTrack(LeadStatusTrack leadStatusTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeadStatusTracks.Add(leadStatusTrack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leadStatusTrack.LeadStatusTrackID }, leadStatusTrack);
        }

        // DELETE: api/LeadStatusTrack/5
        [ResponseType(typeof(LeadStatusTrack))]
        public IHttpActionResult DeleteLeadStatusTrack(int id)
        {
            LeadStatusTrack leadStatusTrack = db.LeadStatusTracks.Find(id);
            if (leadStatusTrack == null)
            {
                return NotFound();
            }

            db.LeadStatusTracks.Remove(leadStatusTrack);
            db.SaveChanges();

            return Ok(leadStatusTrack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeadStatusTrackExists(int id)
        {
            return db.LeadStatusTracks.Count(e => e.LeadStatusTrackID == id) > 0;
        }
    }
}