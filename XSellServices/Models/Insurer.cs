using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class Insurer
    {

        [Key]
        [Display(Name = "Insurer")]
        public int InsurerID { get; set; }

        [Required(ErrorMessage = "The insurer name is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Insurer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The relay code is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Code")]
        [RegularExpression(@"[A-Z]{3}", ErrorMessage = "Relay Code Invalid Format")]
        public string RelayCode { get; set; }


        //public virtual ICollection<Lead> Leads { get; set; }
    }
}