using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CA2.Models;

namespace CA2.Controllers
{
    [Authorize]
    public class LegController : Controller
    {
        private static TourAgencyEntites db = new TourAgencyEntites();

        //
        // GET: /Leg/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Legs.Include(l => l.Trip));
        }

        //
        // GET: /Leg/Details/5

        public ActionResult Details(int id)
        {
            if (id != 0)
            {
                Leg leg = db.Legs.SingleOrDefault(a => a.LegId == id);
                if (leg == null)
                {
                    return HttpNotFound();
                }
                return View(leg);
            }
            return HttpNotFound();
        }

        //
        // GET: /Leg/Create

        public ActionResult Create()
        {
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Name");
            return View();
        }

        //
        // POST: /Leg/Create

        [HttpPost]
        public ActionResult Create(Leg leg, int tripid)
        {
            DateTime startdate = db.Trips.SingleOrDefault(a => a.TripId == tripid).StartDate;
            DateTime enddate = db.Trips.SingleOrDefault(a => a.TripId == tripid).EndDate;

            if (leg.StartDate > enddate | leg.StartDate < startdate)
            {
                return Content("Dates have to be between the trip start date and end date.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Legs.Add(leg);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Name", leg.TripId);
            return View(leg); 
        }

        //
        // GET: /Leg/Edit/5

        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                Leg leg = db.Legs.SingleOrDefault(a => a.LegId == id);
                if (leg == null)
                {
                    return HttpNotFound();
                }
                ViewBag.TripId = new SelectList(db.Trips, "TripId", "Name", leg.TripId);
                return View(leg);
            }
            return HttpNotFound();
        }

        //
        // POST: /Leg/Edit/5

        [HttpPost]
        public ActionResult Edit(Leg leg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TripId = new SelectList(db.Trips, "TripId", "Name", leg.TripId);
            return View(leg);
        }

        //
        // GET: /Leg/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                Leg leg = db.Legs.SingleOrDefault(a => a.LegId == id);
                if (leg == null)
                {
                    return HttpNotFound();
                }
                return View(leg);
            }
            return HttpNotFound();
        }

        //
        // POST: /Leg/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Leg leg = db.Legs.Find(id);
            db.Legs.Remove(leg);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}