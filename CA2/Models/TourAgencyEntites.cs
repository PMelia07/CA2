using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2.Models
{
    public class TourAgencyEntites : DbContext
    {
        public TourAgencyEntites()
            : base("DefaultConnection")
        {

        }
        public DbSet<UserProfile> Users { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Leg> Legs { get; set; }
    }
}
