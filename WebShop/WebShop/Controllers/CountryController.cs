using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CountryController : Controller
    {
        private MarketContext db = new MarketContext();

        //
        // GET: /Country/

        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        //
        // GET: /Country/Details/5

        public ActionResult Details(int id = 0)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        //
        // GET: /Country/Create

        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
                return View("404");
        }

        //
        // POST: /Country/Create

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(country);
        }

        //
        // GET: /Country/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Request.IsAuthenticated)
            {
                Country country = db.Countries.Find(id);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
            }
            else
                return View("404");
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(country);
        }

        //
        // GET: /Country/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Request.IsAuthenticated)
            {
                Country country = db.Countries.Find(id);
                if (country == null)
                {
                    return HttpNotFound();
                }
                return View(country);
            }
            else
                return View("404");
        }

        //
        // POST: /Country/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}