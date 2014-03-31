using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class SearchController : Controller
    {
        IQueryable<VacuumCleaner> repository;
        public ActionResult Index(string returnUrl)
        {
            
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Find(Finder fimv,string returnUrl)
        {
            IQueryable<VacuumCleaner> result = repository.Select(vc => vc);
            if(fimv.searchString!=null)
                if (fimv.searchString.Trim() != "")
                    result = result.Where(vc => vc.model.ToLower().Contains(fimv.searchString.ToLower().Trim())).Select(vc => vc);
            if (fimv.consumerName != null)
                if (fimv.consumerName.Trim() != "")
                    result = result.Where(vc => vc.Consumers.name==fimv.consumerName).Select(vc => vc);
            if (fimv.cleanerType != null)
                if (fimv.cleanerType.Trim() != "")
                    result = result.Where(vc => vc.type == fimv.cleanerType).Select(vc => vc);
            if (fimv.harvestingType != null)
                if (fimv.harvestingType.Trim() != "")
                    result = result.Where(vc => vc.harvestingType == fimv.harvestingType).Select(vc => vc);
            if (fimv.powerType != null)
                if (fimv.powerType.Trim() != "")
                    result = result.Where(vc => vc.powerType == fimv.powerType).Select(vc => vc);
            if (fimv.stackType != null)
                if (fimv.stackType.Trim() != "")
                    result = result.Where(vc => vc.stackType == fimv.stackType).Select(vc => vc);
            ViewBag.returnUrl = returnUrl;
            return View(result.ToList());
        }

        public SearchController()
        {
            VacuumCleanerController vcc = new VacuumCleanerController();
            repository = vcc.SelectAll();
        }

    }
}
