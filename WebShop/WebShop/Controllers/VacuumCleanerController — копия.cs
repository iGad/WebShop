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
        private VacuumCleanerDBContex db = new VacuumCleanerDBContex();

        //
        // GET: /VacuumCleaner/

        public ActionResult Index()
        {
            return View(db.VacuumCleaners.ToList());
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
            return View(vacuumcleaner);
        }

        //
        // POST: /VacuumCleaner/Edit/5

        [HttpPost]
        public ActionResult Edit(VacuumCleaner vacuumcleaner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacuumcleaner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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