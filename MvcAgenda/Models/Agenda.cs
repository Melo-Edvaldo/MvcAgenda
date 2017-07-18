using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAgenda.Models
{
    public class Agenda
    {
        public int ID { get; set; }
        public string ClassName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string HymnName { get; set; }
        public string FirstPrayer { get; set; }
        public string LastPrayer { get; set; }
    }
}
