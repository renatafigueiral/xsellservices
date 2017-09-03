using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class Lead
    {
        [Key]
        [Display(Name = "Lead")]
        public int LeadID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}")]
        [Display(Name = "Renewal Date")]
        public DateTime RenewalDate { get; set; }


        [Required(ErrorMessage = "The portfolio code is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Portfolio Code")]
        [RegularExpression(@"[A-Z0-9]{6}", ErrorMessage = "Portfolio Code Invalid Format")]
        public string PortfolioCode { get; set; }


        //public bool isInbound { get; set; }

        //Foreign Keys
        public int ProductTypeID { get; set; }
        public virtual ProductType ProductType { get; set; }

        ////public int UserID { get; set; }
        //public virtual User CurrentUser { get; set; }

        public int? InsurerID { get; set; }
        public virtual Insurer Insurer { get; set; }

        public int? RankingID { get; set; }
        public virtual Ranking Ranking { get; set; }

        public virtual ICollection<LeadStatusTrack> LeadStatusTracks { get; set; }
        public virtual ICollection<LeadNotesTrack> LeadNotesTracks { get; set; }
    
        
        public virtual ICollection<Call> Calls { get; set; }


    }
}