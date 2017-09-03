using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class ProductType
    {
        [Key]
        [Display(Name = "Product Type")]
        public int ProductTypeID { get; set; }

        [Required(ErrorMessage = "The lead type description is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Product Type Description")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The relay code is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Relay Code")]
        [RegularExpression(@"[A-Z0-9]{2}", ErrorMessage = "Relay Code Invalid Format")]
        public string RelayCode { get; set; }

       //public virtual ICollection<Lead> Leads { get; set; }

    }
}