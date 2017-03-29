using LostAndFound.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostAndFound.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReportLostItem()
        {
            LostItemReportVM vm = new LostItemReportVM();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ReportLostItem(LostItemReportVM vm)
        {           
            return View(vm);
        }
    }
}