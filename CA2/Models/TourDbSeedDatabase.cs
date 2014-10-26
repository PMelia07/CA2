using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CA2.Models
{
    public class TourDbSeedDatabase : DropCreateDatabaseAlways<TourAgencyEntites>
    {
        protected override void Seed(TourAgencyEntites db)
        {
            using (TourAgencyEntites context = new TourAgencyEntites())
            {
                #region Seed Data

                #region "Trip 1"
                Trip trp1 = new Trip
                {
                    Name = "F1 British GP Week along with touring F1 centers.",
                    StartDate = DateTime.Parse("22-06-2013"),
                    EndDate = DateTime.Parse("30-06-2013"),
                    MinGuests = 5

                };

                Leg lg1 = new Leg
                {
                    StartLocation = "Grafton Steet, Dublin, Ireland",
                    StartCity = "Holyhead, United Kingdom",
                    EndCity = "Lotus F1, Enstone, United Kingdom",
                    EndLocation = "Silverstone, UK via Ferry to Hollyhead",
                    StartDate = DateTime.Parse("22-06-2013"),
                    EndDate = DateTime.Parse("22-06-2013"),
                    Trip = trp1,
                    Guests = new List<Guest> { new Guest { Name = "Nathan May" } }
                };

                context.Legs.Add(lg1);
                context.Trips.Add(trp1);
                context.SaveChanges();
                #endregion

                #endregion
            }
        }
    }
}