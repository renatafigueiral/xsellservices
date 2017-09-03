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
    public class RankingController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();

        // GET: api/Ranking
        public IQueryable<Ranking> GetRankings()
        {
            return db.Rankings;
        }

        // GET: api/Ranking/5
        [ResponseType(typeof(Ranking))]
        public IHttpActionResult GetRanking(int id)
        {
            Ranking ranking = db.Rankings.Find(id);
            if (ranking == null)
            {
                return NotFound();
            }

            return Ok(ranking);
        }

        // PUT: api/Ranking/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRanking(int id, Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ranking.RankingID)
            {
                return BadRequest();
            }

            db.Entry(ranking).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankingExists(id))
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

        // POST: api/Ranking
        [ResponseType(typeof(Ranking))]
        public IHttpActionResult PostRanking(Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rankings.Add(ranking);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ranking.RankingID }, ranking);
        }

        // DELETE: api/Ranking/5
        [ResponseType(typeof(Ranking))]
        public IHttpActionResult DeleteRanking(int id)
        {
            Ranking ranking = db.Rankings.Find(id);
            if (ranking == null)
            {
                return NotFound();
            }

            db.Rankings.Remove(ranking);
            db.SaveChanges();

            return Ok(ranking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RankingExists(int id)
        {
            return db.Rankings.Count(e => e.RankingID == id) > 0;
        }
    }
}