using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XSell.Models
{
    public class User
    {

        [Key]
        [Display(Name = "User")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "The insurer name is required")]
        [RegularExpression(@"(PL\)[A-Za-z]+", ErrorMessage = "Windows User Invalid Format")]
        [DataType(DataType.Text)]
        [Display(Name = "Windows User")]
        public string WindowsUser { get; set; }

        //[Required(ErrorMessage = "The relay code is required")]
        //[DataType(DataType.Text)]
        //[Display(Name = "Relay Code")]
        //[RegularExpression(@"[A-Z]{3}", ErrorMessage = "Relay Code Invalid Format")]
        //public string RelayCode { get; set; }

        [InverseProperty("UserImplementer")]
        public virtual ICollection<LeadStatusTrack> LeadStatusTracksImplemented { get; set; }
        [InverseProperty("UserAssigned")]
        public virtual ICollection<LeadStatusTrack> LeadStatusTracksAssigned { get; set; }

        public virtual ICollection<LeadNotesTrack> LeadNotesTracks { get; set; }

        //public virtual ICollection<Lead> Leads { get; set; }

    }
}