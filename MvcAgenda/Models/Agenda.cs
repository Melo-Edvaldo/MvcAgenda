using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAgenda.Models
{
    public class Agenda
    {
        public int ID { get; set; }

        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Class Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Hymn Name")]
        public string HymnName { get; set; }

        [Display(Name = "First Prayer")]
        public string FirstPrayer { get; set; }

        [Display(Name = "Last Prayer")]
        public string LastPrayer { get; set; }
    }
}
