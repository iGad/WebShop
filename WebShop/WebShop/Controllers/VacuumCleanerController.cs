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
            ViewBag.Title = "Catalog";
            var vacuumcleaners = db.VacuumCleaners.Include(v => v.Consumers);
            return View(vacuumcleaners.ToList());
        }

        public List<VacuumCleaner> SelectTop3VC()
        {
            var q = db.VacuumCleaners
                .OrderByDescending(c => c.date)
                .Take(3)
                .Select(c=>c);//from vc in db.VacuumCleaners select vc;
            return q.ToList();
        }

        public IQueryable<VacuumCleaner> SelectAll()
        {
            return db.VacuumCleaners.Select(v=>v);
        }

        public string GetConsumerForCleaner(VacuumCleaner vc)
        {
            return db.Consumers.Where(c => c.id == vc.consumerId).Select(c => c.name).First();
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
                if (Request.Files[0].InputStream.CanRead)
                {
                    byte[] bytes = new byte[Request.Files[0].ContentLength];
                    Request.Files[0].InputStream.Read(bytes, 0, bytes.Length);
                    vacuumcleaner.image = bytes;
                }
                vacuumcleaner.date = DateTime.Now;
                db.VacuumCleaners.Add(vacuumcleaner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name", vacuumcleaner.consumerId);
            return View(vacuumcleaner);
        }

        //
        // GET: /VacuumCleaner/Edit/5
        [HttpGet]
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
        public ActionResult Edit(VacuumCleaner vacuumcleaner)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files[0].ContentLength > 0)
                {
                    byte[] bytes = new byte[Request.Files[0].ContentLength];
                    Request.Files[0].InputStream.Read(bytes, 0, bytes.Length);
                    vacuumcleaner.image = bytes;
                }
                else
                {
                    IQueryable<Byte[]> temp = db.VacuumCleaners.Where(cleaner => cleaner.id == vacuumcleaner.id).Select(c => c.image);
                    vacuumcleaner.image = temp.First();
                }
                db.Entry(vacuumcleaner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.consumerId = new SelectList(db.Consumers, "id", "name", vacuumcleaner.consumerId);
            return View(vacuumcleaner);
        }


        public FileContentResult GetImage(int id)
        {
            VacuumCleaner vc = db.VacuumCleaners.FirstOrDefault(p => p.id == id);
            if (vc != null)
            {
                return File(vc.image,"image/png");
            }
            else
            {
                return null;
            }
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