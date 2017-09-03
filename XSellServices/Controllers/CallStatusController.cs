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
    public class CallStatusController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/CallStatus
        public IQueryable<CallStatus> GetCallStatus()
        {
            return db.CallStatus;
        }

        // GET: api/CallStatus/5
        [ResponseType(typeof(CallStatus))]
        public IHttpActionResult GetCallStatus(int id)
        {
            CallStatus callStatus = db.CallStatus.Find(id);
            if (callStatus == null)
            {
                return NotFound();
            }

            return Ok(callStatus);
        }

        // PUT: api/CallStatus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCallStatus(int id, CallStatus callStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != callStatus.CallStatusID)
            {
                return BadRequest();
            }

            db.Entry(callStatus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallStatusExists(id))
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

        // POST: api/CallStatus
        [ResponseType(typeof(CallStatus))]
        public IHttpActionResult PostCallStatus(CallStatus callStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CallStatus.Add(callStatus);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = callStatus.CallStatusID }, callStatus);
        }

        // DELETE: api/CallStatus/5
        [ResponseType(typeof(CallStatus))]
        public IHttpActionResult DeleteCallStatus(int id)
        {
            CallStatus callStatus = db.CallStatus.Find(id);
            if (callStatus == null)
            {
                return NotFound();
            }

            db.CallStatus.Remove(callStatus);
            db.SaveChanges();

            return Ok(callStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CallStatusExists(int id)
        {
            return db.CallStatus.Count(e => e.CallStatusID == id) > 0;
        }
    }
}