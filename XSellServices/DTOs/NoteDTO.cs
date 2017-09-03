using System;

namespace XSell.DTOs
{
    public class NoteDTO
    {
        public int LeadID { get; set; }

        public string Text { get; set; }

        public DateTime DateTime {get; set;}
 
        public string Author { get; set; }
    }
}