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
    public class PolicyCodeController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/PolicyCode
        public IQueryable<PolicyCode> GetPolicyCodes()
        {
            return db.PolicyCodes;
        }

        // GET: api/PolicyCode/5
        [ResponseType(typeof(PolicyCode))]
        public IHttpActionResult GetPolicyCode(int id)
        {
            PolicyCode policyCode = db.PolicyCodes.Find(id);
            if (policyCode == null)
            {
                return NotFound();
            }

            return Ok(policyCode);
        }

        // PUT: api/PolicyCode/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPolicyCode(int id, PolicyCode policyCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policyCode.PolicyCodeID)
            {
                return BadRequest();
            }

            db.Entry(policyCode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyCodeExists(id))
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

        // POST: api/PolicyCode
        [ResponseType(typeof(PolicyCode))]
        public IHttpActionResult PostPolicyCode(PolicyCode policyCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PolicyCodes.Add(policyCode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PolicyCodeExists(policyCode.PolicyCodeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = policyCode.PolicyCodeID }, policyCode);
        }

        // DELETE: api/PolicyCode/5
        [ResponseType(typeof(PolicyCode))]
        public IHttpActionResult DeletePolicyCode(int id)
        {
            PolicyCode policyCode = db.PolicyCodes.Find(id);
            if (policyCode == null)
            {
                return NotFound();
            }

            db.PolicyCodes.Remove(policyCode);
            db.SaveChanges();

            return Ok(policyCode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolicyCodeExists(int id)
        {
            return db.PolicyCodes.Count(e => e.PolicyCodeID == id) > 0;
        }
    }
}