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
    public class CallController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/Call
        public IQueryable<Call> GetCalls()
        {
            return db.Calls;
        }

        // GET: api/Call/5
        [ResponseType(typeof(Call))]
        public IHttpActionResult GetCall(int id)
        {
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return NotFound();
            }

            return Ok(call);
        }

        // PUT: api/Call/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCall(int id, Call call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != call.CallID)
            {
                return BadRequest();
            }

            db.Entry(call).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CallExists(id))
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

        // POST: api/Call
        [ResponseType(typeof(Call))]
        public IHttpActionResult PostCall(Call call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calls.Add(call);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = call.CallID }, call);
        }

        // DELETE: api/Call/5
        [ResponseType(typeof(Call))]
        public IHttpActionResult DeleteCall(int id)
        {
            Call call = db.Calls.Find(id);
            if (call == null)
            {
                return NotFound();
            }

            db.Calls.Remove(call);
            db.SaveChanges();

            return Ok(call);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CallExists(int id)
        {
            return db.Calls.Count(e => e.CallID == id) > 0;
        }
    }
}