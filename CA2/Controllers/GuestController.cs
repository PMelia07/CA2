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
    public class GuestController : Controller
    {
        private TourAgencyEntites db = new TourAgencyEntites();

        //
        // GET: /Guest/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Guests.Include(g => g.Legs));
        }

        //
        // GET: /Guest/Details/5

        public ActionResult Details(int id = 0)
        {
            if (id != 0)
            {
                Guest guest = db.Guests.Find(id);
                if (guest == null)
                {
                    return HttpNotFound();
                }
                return View(guest);
            }
            return HttpNotFound();
        }

        //
        // GET: /Guest/Create

        public ActionResult Create()
        {
            ViewBag.LegId = new SelectList(db.Legs, "LegId", "StartCity");
            return View();
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LegId = new SelectList(db.Legs, "LegId", "StartCity");
            return View(guest);
        }

        //
        // GET: /Guest/Edit/5

        public ActionResult Edit(int id)
        {
            if (id != 0)
            {
                Guest guest = db.Guests.Find(id);
                if (guest == null)
                {
                    return HttpNotFound();
                }
                ViewBag.LegId = new SelectList(db.Legs, "LegId", "StartCity");
                return View(guest);
            }
            return HttpNotFound();
        }

        //
        // POST: /Guest/Edit/5

        [HttpPost]
        public ActionResult Edit(Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LegId = new SelectList(db.Legs, "LegId", "StartCity");
            return View(guest);
        }

        //
        // GET: /Guest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                Guest guest = db.Guests.Find(id);
                if (guest == null)
                {
                    return HttpNotFound();
                }
                return View(guest);
            }
            return HttpNotFound();
        }

        //
        // POST: /Guest/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}