using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class CallStatus
    {
        [Key]
        [Display(Name = "Call Status")]
        public int CallStatusID { get; set; }

        [Required(ErrorMessage = "The call status description is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Call Status Description")]
        public string Name { get; set; }

        public virtual ICollection<Call> Calls { get; set; }

    }
}