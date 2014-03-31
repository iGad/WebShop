using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebShop.Controllers;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            //CultureInfo ci = new CultureInfo("ru-RU");
            //ci.NumberFormat = new CultureInfo("en-US").NumberFormat;
            //Thread.CurrentThread.CurrentCulture = ci;
            Session.Timeout = 20;
            VacuumCleanerController vcc=new VacuumCleanerController();
            var cg = vcc.SelectTop4VC();
            ViewBag.TopThree = cg;
            return View();
        }



        public ActionResult About()
        {
            ViewBag.Message = "Страница описания приложения.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Страница контактов.";

            return View();
        }
    }
}
