using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XSell.Models
{
    public class PolicyCode
    {
        [Key]
        [ForeignKey("LeadStatusTrack")]
        [Display(Name = "Lead Status Track")]
        public int PolicyCodeID { get; set; }

        [Required(ErrorMessage = "The policy code is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Policy Code")]
        [RegularExpression(@"[A-Z0-9]{6}[0-9]{3}", ErrorMessage = "Policy Code Invalid Format")]
        public string Value { get; set; }

        public virtual LeadStatusTrack LeadStatusTrack { get; set; }

    }
}