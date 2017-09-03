using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class LeadNotesTrack
    {
        [Key]
        [Display(Name = "Lead Notes Track")]
        public int LeadNotesTrackID { get; set; }

        [Required(ErrorMessage = "The note field is required")]
        [StringLength(300)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Note")]
        public string Note { get; set; }

 
        private DateTime? _dateTime;

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}")]
        [Display(Name = "Date Time")]
        public DateTime DateTime
        {
            get { return _dateTime ?? DateTime.UtcNow; }
            set { _dateTime = value; }
        }

        //Foreign Keys
        public int LeadID { get; set; }
        public virtual Lead Lead { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    
    }
}