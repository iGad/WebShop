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
    public class VacuumCleanerController : Controller
    {
        private MarketContext db = new MarketContext();

        //
        // GET: /VacuumCleaner/

        public ActionResult Index()
        {
            var vacuumcleaners = db.VacuumCleaners.Include(v => v.Consumers);
            return View(vacuumcleaners.ToList());
        }

        //
        // GET: /VacuumCleaner/Details/5

        public ActionResult Details(int id = 0)
        {
            VacuumCleaner vacuumcleaner = db.VacuumCleaners.Find(id);
            if (vacuumcleaner == null)
            {
                return HttpNotFound();
            }
            return View(vacuumcleaner);
        }

        //
        // GET: /VacuumCleaner/Create

        public ActionResult Create()
        {
            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name");
            return View();
        }

        //
        // POST: /VacuumCleaner/Create

        [HttpPost]
        public ActionResult Create(VacuumCleaner vacuumcleaner)
        {
            if (ModelState.IsValid)
            {
                db.VacuumCleaners.Add(vacuumcleaner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name", vacuumcleaner.consumerId);
            return View(vacuumcleaner);
        }

        //
        // GET: /VacuumCleaner/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VacuumCleaner vacuumcleaner = db.VacuumCleaners.Find(id);
            if (vacuumcleaner == null)
            {
                return HttpNotFound();
            }
            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name", vacuumcleaner.consumerId);
            return View(vacuumcleaner);
        }

        //
        // POST: /VacuumCleaner/Edit/5

        [HttpPost]
        public ActionResult Edit(VacuumCleaner vacuumcleaner/*, HttpPostedFileBase image*/)
        {
            if (ModelState.IsValid)
            {
                //if (image != null)
                //{
                //    vacuumcleaner.image = new byte[image.ContentLength];
                //    //vacuumcleaner.imageType = image.ContentType;
                //    image.InputStream.Read(vacuumcleaner.image, 0, image.ContentLength);
                //}
                db.Entry(vacuumcleaner).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name", vacuumcleaner.consumerId);
            return View(vacuumcleaner);
        }

        //
        // GET: /VacuumCleaner/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VacuumCleaner vacuumcleaner = db.VacuumCleaners.Find(id);
            if (vacuumcleaner == null)
            {
                return HttpNotFound();
            }
            return View(vacuumcleaner);
        }

        //
        // POST: /VacuumCleaner/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            VacuumCleaner vacuumcleaner = db.VacuumCleaners.Find(id);
            db.VacuumCleaners.Remove(vacuumcleaner);
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