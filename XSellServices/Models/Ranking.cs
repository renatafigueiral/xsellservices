using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XSell.Models
{
    public class Ranking
    {

        [Key]
        [Display(Name = "Ranking")]
        public int RankingID { get; set; }

        [Required(ErrorMessage = "The ranking name is required")]
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Display(Name = "Ranking Name")]
        public string Name { get; set; }

      //  public virtual ICollection<Lead> Leads { get; set; }
    }
}