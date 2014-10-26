using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CA2.Models
{
    public class Trip
    {
        [Key]
        public int TripId { get; set; }
        [Display(Name = "Trip Name"), MaxLength(100, ErrorMessage = "Must be <{1} characters")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public System.DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        //private int _minguests;
        [Display(Name = "No of Guests for trip")]
        public int MinGuests  { get; set; }
        /*{
            get { return _minguests; }

            set
            {
                _minguests = value;
                if (value >= 3)
                {
                    Viable = true;
                }
                else
                {
                    Viable = false;
                }
            }
        }*/
        [Display(Name = "Trip Viable?")]
        public bool Viable { get; set; }

        //private bool _Complete;
        [Display(Name = "Trip Complete?")]
        public bool Complete { get; set; }
        /*{
            get
            {
                List<Leg> legs = Legs.OrderBy(l => l.StartDate);
                List<Leg> legsList = new List<Leg>();

                foreach (Leg l in legs)
                {
                    legsList.Add(l);
                }
                int legsCount = legsList.Count();
                if (legsList[0].StartDate != StartDate || legsList[legsCount - 1].EndDate != EndDate) 
                {
                    _Complete = false;
                    return _Complete;
                }
                for (int i = 0; i < legsCount - 1; i++)
                {
                    if ((legs.ElementAt(i + 1).StartDate - legs.ElementAt(i).EndDate).Days != 1)
                    {
                    _Complete = false;
                    break;
                    }
                    else
                    {
                    _Complete = true;
                    }
                }
                return _Complete;
            }
            set 
            {
                _Complete = value;
            }
        }*/

        [Display(Name = "List of Legs")]
        public virtual List<Leg> Legs {get; set; }  
    }
}
