using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class ActionCall
    {
        [Key]
        [Display(Name = "Action Call")]
        public int ActionCallID { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}")]
        [Display(Name = "Action Execute Date")]
        public string ActionExecuteDate { get; set; }


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
 
        public int ActionTypeID { get; set; }
        public virtual ActionType ActionType { get; set; }

  
     }
}