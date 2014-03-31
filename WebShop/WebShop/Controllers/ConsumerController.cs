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
    public class ConsumerController : Controller
    {
        private MarketContext db = new MarketContext();

        //
        // GET: /Consumer/

        public ActionResult Index()
        {
            var consumers = db.Consumers.Include(c => c.Countries);
            return View(consumers.ToList());
        }

        //
        // GET: /Consumer/Details/5

        public ActionResult Details(int id = 0)
        {
            Consumer consumer = db.Consumers.Find(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
        }

        //
        // GET: /Consumer/Create

        public ActionResult Create()
        {
            if (Request.IsAuthenticated)
            {
                ViewBag.countryId = new SelectList(db.Countries, "id", "name");
                return View();
            }
            else
                return View("404");
        }

        //
        // POST: /Consumer/Create

        [HttpPost]
        public ActionResult Create(Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Consumers.Add(consumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryId = new SelectList(db.Countries, "id", "name", consumer.countryId);
            return View(consumer);
        }

        //
        // GET: /Consumer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (Request.IsAuthenticated)
            {
                Consumer consumer = db.Consumers.Find(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                ViewBag.countryId = new SelectList(db.Countries, "id", "name", consumer.countryId);
                return View(consumer);
            }
            else
                return View("404");
        }

        //
        // POST: /Consumer/Edit/5

        [HttpPost]
        public ActionResult Edit(Consumer consumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countryId = new SelectList(db.Countries, "id", "name", consumer.countryId);
            return View(consumer);
        }

        //
        // GET: /Consumer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (Request.IsAuthenticated)
            {
                Consumer consumer = db.Consumers.Find(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            else
                return View("404");
        }

        //
        // POST: /Consumer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumer consumer = db.Consumers.Find(id);
            db.Consumers.Remove(consumer);
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