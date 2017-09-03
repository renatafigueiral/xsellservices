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
    public class LeadController : ApiController
    {
        private XSellServicesContext db = new XSellServicesContext();


        [Route("~/api/lead/dto")]
        public IQueryable<LeadDTO> GetLeadsDTO()
        {
            var leads = from lead in db.Leads
                        select new LeadDTO()
                        {
                            LeadID = lead.LeadID,
                            RenewalDate = lead.RenewalDate,
                            PortfolioCode = lead.PortfolioCode,
                            ProductType = lead.ProductType.Name,
                            Insurer = lead.Insurer.Name,
                            CurrentSatus = lead.LeadStatusTracks.OrderByDescending(s => s.DateTime).FirstOrDefault().LeadStatus.Name
                        };
            return leads;
        }


        [Route("~/api/lead/dto/byuser/{windowsUser}")]
        public IQueryable<LeadDTO> GetLeadsDTOByUser(string windowsUser)
        {
            User user = db.Users.Where(u => u.WindowsUser == windowsUser).FirstOrDefault();
            var leadsStatusTracks = user.LeadStatusTracksAssigned;
            var leads = from leadST in leadsStatusTracks
                        select new LeadDTO()
                        {
                            LeadID = leadST.LeadID,
                            RenewalDate = leadST.Lead.RenewalDate,
                            PortfolioCode = leadST.Lead.PortfolioCode,
                            ProductType = leadST.Lead.ProductType.Name,
                            Insurer = leadST.Lead.Insurer.Name,
                            CurrentSatus = leadST.Lead.LeadStatusTracks.OrderByDescending(s => s.DateTime).FirstOrDefault().LeadStatus.Name
                        };
            return leads as IQueryable<LeadDTO>;

        }



        [Route("~/api/leaddetails/dto/byuser/{windowsUser}")]
        public IQueryable<LeadDetailsDTO> GetLeadsDetailsDTOByUser(string windowsUser)
        {
            User user = db.Users.Where(u => u.WindowsUser == windowsUser).FirstOrDefault();
            var leadsStatusTracks = user.LeadStatusTracksAssigned;
            var leadsDetails = from leadST in leadsStatusTracks
                               select new LeadDetailsDTO()
                               {
                                   LeadID = leadST.LeadID,
                                   RenewalDate = leadST.Lead.RenewalDate,
                                   PortfolioCode = leadST.Lead.PortfolioCode,
                                   ProductType = leadST.Lead.ProductType.Name,
                                   Insurer = leadST.Lead.Insurer.Name,
                                   CurrentSatus = leadST.Lead.LeadStatusTracks.OrderByDescending(s => s.DateTime).FirstOrDefault().LeadStatus.Name,
                                   Notes = from note in leadST.Lead.LeadNotesTracks
                                           select new NoteDTO()
                                           {
                                              // LeadID = note.LeadID,
                                               Text = note.Note,
                                               DateTime = note.DateTime,
                                               Author = note.User.WindowsUser
                                           }
                               };

            return leadsDetails.AsQueryable();
        }


        [Route("~/api/lead/dto/bycustomer/{portfolioNumber}")]
        public IQueryable<LeadDTO> GetLeadsDTOByCustomer(string portfolioNumber)
        {
            var leads = from lead in db.Leads
                        where lead.PortfolioCode == portfolioNumber
                        select new LeadDTO()
                        {
                            LeadID = lead.LeadID,
                            RenewalDate = lead.RenewalDate,
                            PortfolioCode = lead.PortfolioCode,
                            ProductType = lead.ProductType.Name,
                            Insurer = lead.Insurer.Name,
                            CurrentSatus = lead.LeadStatusTracks.OrderByDescending(s => s.DateTime).FirstOrDefault().LeadStatus.Name
                        };

            return leads;
        }

        [Route("~/api/leaddetails/dto/bycustomer/{portfolioNumber}")]
        public IQueryable<LeadDetailsDTO> GetLeadsDetailsDTOByCustomer(string portfolioNumber)
        {
            var leadsDetails = from lead in db.Leads
                               where lead.PortfolioCode == portfolioNumber
                               select new LeadDetailsDTO()
                               {
                                   LeadID = lead.LeadID,
                                   RenewalDate = lead.RenewalDate,
                                   PortfolioCode = lead.PortfolioCode,
                                   ProductType = lead.ProductType.Name,
                                   Insurer = lead.Insurer.Name,
                                   CurrentSatus = lead.LeadStatusTracks.OrderByDescending(s => s.DateTime).FirstOrDefault().LeadStatus.Name,
                                   Notes = from note in lead.LeadNotesTracks
                                           select new NoteDTO()
                                           {
                                               //LeadID = note.LeadID,
                                               Text = note.Note,
                                               DateTime = note.DateTime,
                                               Author = note.User.WindowsUser
                                           }
                               };

            return leadsDetails;
        }


        // GET: api/Lead
        public IQueryable<Lead> GetLeads()
        {
            return db.Leads.Include(p => p.ProductType);
        }

        // GET: api/Lead/5
        [ResponseType(typeof(Lead))]
        public IHttpActionResult GetLead(int id)
        {
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }

        // PUT: api/Lead/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLead(int id, Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lead.LeadID)
            {
                return BadRequest();
            }

            db.Entry(lead).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Lead
        [ResponseType(typeof(Lead))]
        public IHttpActionResult PostLead(Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leads.Add(lead);
            db.SaveChanges();
            Lead lead2 = db.Leads.Include(p => p.ProductType).SingleOrDefault(s => (s.LeadID == lead.LeadID));
            return CreatedAtRoute("DefaultApi", new { id = lead.LeadID }, lead2);
        }


        // POST: api/Lead
        [Route("~/api/leaddetails/dto/createlead/{author}")]
        [ResponseType(typeof(Lead))]
        public IHttpActionResult CreateLead(string author, LeadDetailsDTO lead)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Lead newLead = new Lead();

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    User user = db.Users.SingleOrDefault(s => (s.WindowsUser == author));
                    if (user == null)
                    {
                        return NotFound();
                    }
                    if (lead.RenewalDate != null)
                    {
                        newLead.RenewalDate = (DateTime)lead.RenewalDate;
                    }else
                    {
                        newLead.RenewalDate = DateTime.Parse("1900-01-01");
                    }
                    newLead.PortfolioCode = lead.PortfolioCode;
                    newLead.ProductTypeID = lead.ProductTypeID;
                    newLead.ProductType = db.ProductTypes.Find(lead.ProductTypeID);
                    newLead.InsurerID = lead.InsurerID;
                    newLead.Insurer = db.Insurers.Find(lead.InsurerID);
                    newLead.RankingID = lead.RankingID;
                    newLead.Ranking = db.Rankings.Find(lead.RankingID);

                    db.Leads.Add(newLead);
                    db.SaveChanges();

                    if (lead.Notes != null)
                    {
                        LeadNotesTrack newNote = new LeadNotesTrack()
                        {
                            Note = lead.Notes.FirstOrDefault().Text,
                            LeadID = newLead.LeadID,
                            UserID = user.UserID,
                        };
                        db.LeadNotesTracks.Add(newNote);
                        db.SaveChanges();
                    }

                    // Status Created
                    LeadStatusTrack newStatus = new LeadStatusTrack()
                    {
                        LeadStatusID = 1,
                        LeadStatus = db.LeadStatus.Find(1),
                        LeadID = newLead.LeadID,
                        UserImplementerID = user.UserID,
                    };
                    db.LeadStatusTracks.Add(newStatus);
                    db.SaveChanges();

                    dbContextTransaction.Commit();
                }
                catch (DataException ex)
                {
                    dbContextTransaction.Rollback();
                    return BadRequest("SaveChanges error: "+ex.InnerException);
                 }
            }
            //var leadSent = db.Leads.Find(newLead.LeadID);
            // return Ok(leadSent);
            return CreatedAtRoute("DefaultApi", new {controller="Lead", id = newLead.LeadID }, newLead);
        }


        // DELETE: api/Lead/5
        [ResponseType(typeof(Lead))]
        public IHttpActionResult DeleteLead(int id)
        {
            Lead lead = db.Leads.Find(id);
            if (lead == null)
            {
                return NotFound();
            }

            db.Leads.Remove(lead);
            db.SaveChanges();

            return Ok(lead);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeadExists(int id)
        {
            return db.Leads.Count(e => e.LeadID == id) > 0;
        }
    }
}