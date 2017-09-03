using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class Reason
    {
        [Key]
        [Display(Name = "Reason")]
        public int ReasonID { get; set; }

        [Required(ErrorMessage = "The reason description is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Reason Description")]
        public string Name { get; set; }

        public virtual ICollection<LeadStatusTrack> LeadStatusTrack{ get; set; }

    }
}