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
    public class ActionTypeController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/ActionType
        public IQueryable<ActionType> GetActionTypes()
        {
            return db.ActionTypes;
        }

        // GET: api/ActionType/5
        [ResponseType(typeof(ActionType))]
        public IHttpActionResult GetActionType(int id)
        {
            ActionType actionType = db.ActionTypes.Find(id);
            if (actionType == null)
            {
                return NotFound();
            }

            return Ok(actionType);
        }

        // PUT: api/ActionType/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActionType(int id, ActionType actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actionType.ActionTypeID)
            {
                return BadRequest();
            }

            db.Entry(actionType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionTypeExists(id))
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

        // POST: api/ActionType
        [ResponseType(typeof(ActionType))]
        public IHttpActionResult PostActionType(ActionType actionType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ActionTypes.Add(actionType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actionType.ActionTypeID }, actionType);
        }

        // DELETE: api/ActionType/5
        [ResponseType(typeof(ActionType))]
        public IHttpActionResult DeleteActionType(int id)
        {
            ActionType actionType = db.ActionTypes.Find(id);
            if (actionType == null)
            {
                return NotFound();
            }

            db.ActionTypes.Remove(actionType);
            db.SaveChanges();

            return Ok(actionType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActionTypeExists(int id)
        {
            return db.ActionTypes.Count(e => e.ActionTypeID == id) > 0;
        }
    }
}