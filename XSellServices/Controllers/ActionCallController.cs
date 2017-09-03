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
    public class ActionCallController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/ActionCall
        public IQueryable<ActionCall> GetActionCalls()
        {
            return db.ActionCalls;
        }

        // GET: api/ActionCall/5
        [ResponseType(typeof(ActionCall))]
        public IHttpActionResult GetActionCall(int id)
        {
            ActionCall actionCall = db.ActionCalls.Find(id);
            if (actionCall == null)
            {
                return NotFound();
            }

            return Ok(actionCall);
        }

        // PUT: api/ActionCall/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActionCall(int id, ActionCall actionCall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionCall.ActionCallID)
            {
                return BadRequest();
            }

            db.Entry(actionCall).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionCallExists(id))
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

        // POST: api/ActionCall
        [ResponseType(typeof(ActionCall))]
        public IHttpActionResult PostActionCall(ActionCall actionCall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActionCalls.Add(actionCall);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actionCall.ActionCallID }, actionCall);
        }

        // DELETE: api/ActionCall/5
        [ResponseType(typeof(ActionCall))]
        public IHttpActionResult DeleteActionCall(int id)
        {
            ActionCall actionCall = db.ActionCalls.Find(id);
            if (actionCall == null)
            {
                return NotFound();
            }

            db.ActionCalls.Remove(actionCall);
            db.SaveChanges();

            return Ok(actionCall);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionCallExists(int id)
        {
            return db.ActionCalls.Count(e => e.ActionCallID == id) > 0;
        }
    }
}