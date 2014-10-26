using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using CA2.Models;

namespace CA2.Controllers
{
    [Authorize]
    public class TripController : Controller
    {
        //
        // GET: /Trip/

        private static TourAgencyEntites db = new TourAgencyEntites();

        //
        // GET: /Trip/
        [AllowAnonymous]
        public ActionResult Index()//int tripId, Trip trip)
        {
            /*if (ModelState.IsValid)
            {
                using (TourAgencyEntites dbo = new TourAgencyEntites())
                {
                    int triplength = (int)(trip.EndDate - trip.StartDate).TotalDays;
                    List<Leg> triplegs = dbo.Legs.Where(a => a.Trip.TripId == trip.TripId).ToList();
                    //get all dates from legs
                    int leglength = 0;

                    foreach (Leg ileg in triplegs)
                    {
                        TimeSpan numberofdays = (ileg.EndDate.Date.AddDays(1)) - ileg.StartDate.Date;
                        leglength = (int)(leglength + numberofdays.TotalDays);

                        if (triplength != leglength)
                        {
                            trip.Complete = false;
                            db.SaveChanges();
                        }
                        else
                        {
                            trip.Complete = true;
                        }
                    }


                    bool viable =
                        dbo.Trips.SingleOrDefault(a => a.TripId == tripId).Legs.Where(a => a.Guests.Count >= 3).Count() >= 2;
                    dbo.Trips.SingleOrDefault(a => a.TripId == tripId).Viable = viable;

                    if (viable != true)
                    {
                        viable = false;
                    }
                    else
                    {
                        viable = true;
                    }    
                }*/
                return View(db.Trips.Include(l => l.Legs));
            //}
        }

        //
        // GET: /Trip/Details/5

        public ActionResult Details(int id)
        {
            if (id != 0)
            {
                Trip trip = db.Trips.Find(id);
                if (trip == null)
                {
                    return HttpNotFound();
                }
                return View(trip);
            }
            return HttpNotFound();
        }

        //
        // GET: /Trip/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trip/Create

        [HttpPost]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Trip/Edit/5

        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                Trip trip = db.Trips.SingleOrDefault(a => a.TripId == id);
                if (trip == null)
                {
                    return HttpNotFound();
                }
                return View(trip);
            }
            return HttpNotFound();
        }

        //
        // POST: /Trip/Edit/5

        [HttpPost]
        public ActionResult Edit(Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(trip);
        }

        //
        // GET: /Trip/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                Trip trip = db.Trips.SingleOrDefault(a => a.TripId == id);
                if (trip == null)
                {
                    return HttpNotFound();
                }
                return View(trip);
            }
            return HttpNotFound();
        }

        //
        // POST: /Trip/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Trip trip = db.Trips.Find(id);
            db.Trips.Remove(trip);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}