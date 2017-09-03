using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XSellServices.Models;

namespace XSell.DTOs
{
    public class LeadDTO
    {
        public int LeadID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RenewalDate { get; set; }

        public string PortfolioCode { get; set; }

        public string ProductType { get; set; }

        public string Insurer { get; set; }

        public string CurrentSatus { get; set; }

    }

    public class LeadDetailsDTO
    {
        public int LeadID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RenewalDate { get; set; }

        public string PortfolioCode { get; set; }

        public int ProductTypeID { get; set; }

        public string ProductType { get; set; }

        public int? InsurerID { get; set; }

        public string Insurer { get; set; }

        public int? RankingID { get; set; }

        public string Ranking { get; set; }

        public string CurrentSatus { get; set; }

        public IEnumerable<NoteDTO> Notes { get; set; }

    }

}