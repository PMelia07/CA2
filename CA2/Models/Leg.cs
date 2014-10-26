using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CA2.Models
{
    public class Leg
    {
        [Key]
        public int LegId { get; set; }

        [Required]
        [Display(Name = "Start Location"), MaxLength(50, ErrorMessage = "Must be <{1} characters")]
        public string StartLocation { get; set; }

        [Required]
        [Display(Name = "End Location"), MaxLength(50, ErrorMessage = "Must be <{1} characters")]
        public string EndLocation { get; set; }

        [Required]
        [Display(Name = "Start City"), MaxLength(50, ErrorMessage = "Must be <{1} characters")]
        public string StartCity { get; set; }

        [Required]
        [Display(Name = "End City"), MaxLength(50, ErrorMessage = "Must be <{1} characters")]
        public string EndCity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "List of Guest")]
        public virtual List<Guest> Guests { get; set; }

        //Navigation Property
        [Required]
        [Display(Name = "Trip")]
        public int TripId { get; set; }
        [Required]
        public Trip Trip { get; set; }
    }
}

