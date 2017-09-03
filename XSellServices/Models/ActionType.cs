using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class ActionType
    {
        [Key]
        [Display(Name = "Action Type")]
        public int ActionTypeID { get; set; }

        [Required(ErrorMessage = "The action type description is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Action Type Description")]
        public string Name { get; set; }

        public virtual ICollection<ActionCall> ActionCalls{ get; set; }

    }
}