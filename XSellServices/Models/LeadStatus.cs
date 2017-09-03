using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class LeadStatus
    {
        [Key]
        [Display(Name = "Lead Status")]
        public int LeadStatusID { get; set; }

        [Required(ErrorMessage = "The lead status description is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Lead Status Description")]
        public string Name { get; set; }

       // public virtual ICollection<LeadStatusTrack> LeadStatusTrack{ get; set; }

    }
}