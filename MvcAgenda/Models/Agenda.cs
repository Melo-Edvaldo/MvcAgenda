using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAgenda.Models
{
    public class Agenda
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Class Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Hymn Name")]
        public string HymnName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "First Prayer")]
        public string FirstPrayer { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Last Prayer")]
        public string LastPrayer { get; set; }
    }
}
