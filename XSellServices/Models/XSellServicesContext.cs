using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XSellServices.Models
{
    public class XSellServicesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public XSellServicesContext() : base("name=XSellServicesContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public System.Data.Entity.DbSet<XSell.Models.ActionCall> ActionCalls { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.ActionType> ActionTypes { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.Call> Calls { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.CallStatus> CallStatus { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.Lead> Leads { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.Insurer> Insurers { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.ProductType> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.Ranking> Rankings { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.LeadNotesTrack> LeadNotesTracks { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.LeadStatus> LeadStatus { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.LeadStatusTrack> LeadStatusTracks { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.PolicyCode> PolicyCodes { get; set; }

        public System.Data.Entity.DbSet<XSell.Models.Reason> Reasons { get; set; }
    }
}
