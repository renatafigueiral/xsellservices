using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class Call
    {
        [Key]
        [Display(Name = "Call")]
        public int CallID { get; set; }

       // [Required(ErrorMessage = "The phone is required")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Customer Phone")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "The Inbound/Outbound call field is required")]
        [Display(Name = "Inbound/Outbound Call")]
        public bool IsOutboundCall { get; set; }

        [Required(ErrorMessage = "The data protection field is required")]
        [Display(Name = "Data Protection")]
        public bool IsValidDataProtection { get; set; }

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

        public int CallStatusID { get; set; }
        public virtual CallStatus CallStatus { get; set; }

        public int? ActionCallID { get; set; }
        public virtual ActionCall Action { get; set; }


    }
}