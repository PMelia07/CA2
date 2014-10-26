using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CA2.Models
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        [Required]
        [Display(Name = "Guest Name"), MaxLength(50, ErrorMessage = "Must be <{1} characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "List of Legs")]
        public ICollection<Leg> Legs { get ; set; }
        public int LegId { get; set; }
    }
}
