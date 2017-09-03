using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XSell.Models
{
    public class LeadStatusTrack
    {
        [Key]
        [Display(Name = "Lead Status Track")]
        public int LeadStatusTrackID { get; set; }

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

        public int UserImplementerID { get; set; }
        [ForeignKey("UserImplementerID")]
        public virtual User UserImplementer { get; set; }

        public int? UserAssignedID { get; set; }
        [ForeignKey("UserAssignedID")]
        public virtual User UserAssigned { get; set; }

        public int LeadStatusID { get; set; }
        public virtual LeadStatus LeadStatus { get; set; }

        public virtual PolicyCode PolicyCode { get; set; }

        public virtual ICollection<Reason> Reason { get; set; }
     }
}