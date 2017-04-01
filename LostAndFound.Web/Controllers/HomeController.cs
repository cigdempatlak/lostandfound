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
                            ).OrderByDescending(c => c.DateLost).ToList();
            return View(vm);
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

        [Authorize]
        [HttpGet]
        public ActionResult Claim()
        {
            AppDbContext db = new AppDbContext();

            ListLostReportItemVM vm = new ListLostReportItemVM();

            vm.LostItems = (from li in db.LostItemReports
                             where li.Active == true && li.Approved == true
                             orderby li.LostDateTimeUTC descending
                             select new LostItem
                             {
                                 DateLost = li.LostDateTimeUTC,
                                 ItemName = li.ItemName,
                                 ItemType = li.LostItemType.Name,
                                 Location = li.LostLocation.Name,
                                 ItemId = li.LostReportItemId
                             }
                            ).ToList();

            return View(vm);
            
        }

        [HttpPost]
        [Authorize]
        public ActionResult Claim(ListLostReportItemVM vm)
        {
            AppDbContext db = new AppDbContext();

           
            vm.LostItems = (from li in db.LostItemReports
                            where li.Active == vm.SearchActiveOnly && li.Approved == true && (String.IsNullOrEmpty(vm.SearchItemName) || li.ItemName.Contains(vm.SearchItemName))
                            orderby li.LostDateTimeUTC descending
                            select new LostItem
                            {
                                DateLost = li.LostDateTimeUTC,
                                ItemName = li.ItemName,
                                ItemType = li.LostItemType.Name,
                                Location = li.LostLocation.Name,
                                ItemId = li.LostReportItemId
                            }
                            ).ToList();

            return View(vm);

        }

        [Authorize]
        [HttpGet]
        public ActionResult EditCase(Guid? itemId)
        {
            if (itemId == null)
                return RedirectToAction("Index");

            AppDbContext db = new AppDbContext();

            LostItemReport lir = db.LostItemReports.Include("LostLocation").Include("LostItemType").Single(c => c.LostReportItemId == itemId);

            CloseCaseVM vm = MapToCloseCaseVM(lir);

            if (lir.Active == false)
                return View("CaseClosed", vm);

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditCase(Guid itemId,CloseCaseVM vm, DateTime? FoundDate, string Notes, string ReasonCaseClosed,
            string ClaimerFirstName, string ClaimerLastName,string ClaimerEmail,DateTime? CaseClosedDate, bool KeepCaseOpen)
        {
            AppDbContext db = new AppDbContext();

            AppUser user = db.Users.Single(c => c.Email == this.User.Identity.Name);
            LostItemReport lir = db.LostItemReports.Include("LostLocation").Include("LostItemType").Single(c => c.LostReportItemId == itemId);

            vm = MapToCloseCaseVM(lir);
            if (lir.Active == false)
                return View("CaseClosed", vm);

            if (FoundDate.HasValue)
                vm.FoundDate = FoundDate.Value;
            vm.Notes = Notes;
            vm.ReasonCaseClosed = ReasonCaseClosed;
            vm.ClaimerFirstName = ClaimerFirstName;
            vm.ClaimerLastName = ClaimerLastName;
            vm.ClaimerEmail = ClaimerEmail;
         
            if (KeepCaseOpen == false)
            {
                vm.CaseClosedBy = user;
                
                if (!TryUpdateModel(vm))
                {
                    return View(vm);
                }

                lir.CaseClosedBy = user;
                lir.Active = false;              
            }
            

            lir.Notes = vm.Notes;
            lir.ReasonCaseClosed = vm.ReasonCaseClosed;
            lir.ClaimerFirstName = vm.ClaimerFirstName;
            lir.ClaimerLastName = vm.ClaimerLastName;
            lir.ClaimerEmail = vm.ClaimerEmail;
            if (FoundDate.HasValue)
                lir.FoundDateInUtc = FoundDate.Value.ToUniversalTime();
            if (CaseClosedDate.HasValue)
                lir.CaseClosedDateUTC = CaseClosedDate.Value.ToUniversalTime();
         


            db.SaveChanges();

            if (lir.Active == false)
                return View("CaseClosed", vm);

            TempData["message"] = "Case is updated.";
            return RedirectToAction("EditCase", new { itemId = itemId });
        }

        private CloseCaseVM MapToCloseCaseVM(LostItemReport lir)
        {
            CloseCaseVM vm = new CloseCaseVM();
            vm.Active = lir.Active == true ? "Active" : "Closed";
            if (lir.FoundDateInUtc.HasValue)
                vm.FoundDate = lir.FoundDateInUtc.Value.ToLocalTime();
            vm.KeepCaseOpen = lir.Active;
            vm.Approved = lir.Approved == true ? "Approved" : "Not Approved";
            vm.DateCreated = lir.DateCreatedUTC.ToLocalTime();
            vm.Description = lir.Description;
            vm.Email = lir.Email;
            vm.Name = string.Format("{0} {1}", lir.FirstName, lir.LastName);
            vm.IPAdress = lir.IPAdress;
            vm.ItemName = lir.ItemName;
            vm.LostDateTime = lir.LostDateTimeUTC.ToLocalTime();
            vm.LostItemType = lir.LostItemType.Name;
            vm.LostLocation = lir.LostLocation.Name;
            vm.Notes = lir.Notes;
            vm.Phone = lir.Phone;
            vm.ReasonCaseClosed = lir.ReasonCaseClosed;
            vm.RecordEnteredBy = lir.RecordEnteredBy;
            if (lir.FoundDateInUtc.HasValue)
                vm.FoundDate = lir.FoundDateInUtc.Value.ToLocalTime();
            vm.ClaimerEmail = lir.ClaimerEmail;
            vm.ClaimerFirstName = lir.ClaimerFirstName;
            vm.ClaimerLastName = lir.ClaimerLastName;
          
            return vm;
        }
    }
}