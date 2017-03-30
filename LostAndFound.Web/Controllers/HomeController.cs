using LostAndFound.Data.Entities;
using LostAndFound.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LostAndFound.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();

            ListLostReportItemVM vm = new ListLostReportItemVM();

            vm.LostItems = (from li in db.LostItemReports
                            where li.Active == true && li.Approved == true
                            select new LostItem
                            {
                                DateLost = li.LostDateTimeUTC,
                                ItemName = li.ItemName,
                                ItemType = li.LostItemType.Name,
                                Location = li.LostLocation.Name
                            }
                            ).ToList();
            return View(vm);
        }

      
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ReportLostItem()
        {
            LostItemReportVM vm = new LostItemReportVM();

            AppDbContext db = new AppDbContext();
            vm.Location = db.Locations.Where(c => c.Active == true).OrderBy(c => c.Name).
                                  Select(c => new LostLocation { Key = c.LocationId, Name = c.Name }).ToList();
            vm.ItemType = db.TypeOfItems.Where(c => c.Active == true).OrderBy(c => c.Name).
                            Select(c => new LostItemType { Key = c.TypeOfItemId, Name = c.Name }).ToList();

            return View(vm);
        }

        [ValidateAntiForgeryToken]  
        [HttpPost]
        public ActionResult ReportLostItem(LostItemReportVM vm)
        {
            AppDbContext db = new AppDbContext();

            if (!ModelState.IsValid)
            {
                vm.Location = db.Locations.Where(c => c.Active == true).OrderBy(c=>c.Name).
                                  Select(c => new LostLocation { Key = c.LocationId, Name = c.Name }).ToList();
                vm.ItemType = db.TypeOfItems.Where(c => c.Active == true).OrderBy(c=>c.Name).
                                Select(c => new LostItemType { Key = c.TypeOfItemId, Name = c.Name }).ToList();
                return View(vm);
            }

            try
            {
                //for now lets add all items by sysadmin
                AppUser sysAdmin = db.Users.SingleOrDefault(c => c.Email == "lostandfoundapp@devign34.com");

                LostItemReport lostItem = new LostItemReport();
                lostItem.Active = true;
                lostItem.DateCreatedUTC = DateTime.UtcNow;
                lostItem.Description = vm.Description;
                lostItem.Email = vm.Email;
                lostItem.FirstName = vm.FirstName;
                lostItem.IPAdress = Request.UserHostAddress;
                lostItem.ItemName = vm.ItemName;
                lostItem.LastName = vm.LastName;
                lostItem.LostDateTimeUTC = vm.LostDateTime.ToUniversalTime();
                lostItem.LostReportItemId = Guid.NewGuid();
                lostItem.Phone = vm.Phone;
                lostItem.RecordEnteredBy = sysAdmin;
                lostItem.LostLocation = db.Locations.Single(c => c.LocationId == vm.SelectedLocationID);
                lostItem.LostItemType = db.TypeOfItems.Single(c => c.TypeOfItemId == vm.SelectedItemType);

                db.LostItemReports.Add(lostItem);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}