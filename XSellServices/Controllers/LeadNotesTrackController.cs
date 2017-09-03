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
using XSell.DTOs;

namespace XSellServices.Controllers
{
    public class LeadNotesTrackController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/LeadNotesTrack
        public IQueryable<LeadNotesTrack> GetLeadNotesTracks()
        {
            return db.LeadNotesTracks;
        }

        // GET: api/LeadNotesTrack/5
        [ResponseType(typeof(LeadNotesTrack))]
        public IHttpActionResult GetLeadNotesTrack(int id)
        {
            LeadNotesTrack leadNotesTrack = db.LeadNotesTracks.Find(id);
            if (leadNotesTrack == null)
            {
                return NotFound();
            }

            return Ok(leadNotesTrack);
        }


        [Route("~/api/notes/dto/{leadid}")]
        public IQueryable<NoteDTO> GetNotesDTOByLead(int leadid)
        {
            var notes = from note in db.LeadNotesTracks
                        where note.LeadID == leadid
                        select new NoteDTO()
                        {
                            Text = note.Note,
                            DateTime = note.DateTime,
                            Author = note.User.WindowsUser
                        };
            return notes;
        }


        // PUT: api/LeadNotesTrack/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeadNotesTrack(int id, LeadNotesTrack leadNotesTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leadNotesTrack.LeadNotesTrackID)
            {
                return BadRequest();
            }

            db.Entry(leadNotesTrack).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadNotesTrackExists(id))
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

        // POST: api/LeadNotesTrack
        [ResponseType(typeof(LeadNotesTrack))]
        public IHttpActionResult PostLeadNotesTrack(LeadNotesTrack leadNotesTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LeadNotesTracks.Add(leadNotesTrack);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = leadNotesTrack.LeadNotesTrackID }, leadNotesTrack);
        }

        // DELETE: api/LeadNotesTrack/5
        [ResponseType(typeof(LeadNotesTrack))]
        public IHttpActionResult DeleteLeadNotesTrack(int id)
        {
            LeadNotesTrack leadNotesTrack = db.LeadNotesTracks.Find(id);
            if (leadNotesTrack == null)
            {
                return NotFound();
            }

            db.LeadNotesTracks.Remove(leadNotesTrack);
            db.SaveChanges();

            return Ok(leadNotesTrack);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeadNotesTrackExists(int id)
        {
            return db.LeadNotesTracks.Count(e => e.LeadNotesTrackID == id) > 0;
        }
    }
}