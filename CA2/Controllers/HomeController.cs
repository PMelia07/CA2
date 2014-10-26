using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2.Models;

namespace CA2.Controllers
{
    public class HomeController : Controller
    {
        private static TourAgencyEntites db = new TourAgencyEntites();

        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Search(ViewModels.SearchCriteria criteria)
        {
            string bookingCriteria = string.Empty;

            if (!string.IsNullOrWhiteSpace(criteria.GuestName))
            bookingCriteria = criteria.GuestName.ToLower().Trim();

            IQueryable<Models.Leg> results = db.Legs;

            if (bookingCriteria != string.Empty)
            {
                //Code to try and get the information from the datebase, when you input an Guest Name
                //That will retrive the legs of a booking from a Guest with that Name
                results = (from guest in results
                            from legs in guest.Guests
                            where legs.Name.ToLower().
                            Contains(bookingCriteria)
                            select guest).Distinct();
            }
            results = results.Include(b => b.Guests).
                OrderBy(b => b.LegId);

            return PartialView("SearchResults", results.ToList());
        }
    }
}
