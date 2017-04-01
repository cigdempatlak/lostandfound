using LostAndFound.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LostAndFound.Web.Models
{
    public class CloseCaseVM
    {
        public Guid LostReportItemId { get; set; }

        [Display(Name ="Item Name")]       
        public string ItemName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name ="Item Type")]
        public string LostItemType { get; set; }

        [Display(Name ="Item Reported by")]
        public string Name { get; set; }

        [Display(Name ="Location Lost")]
        public string LostLocation { get; set; }

        [Display(Name ="Ttem Reported by (Email)")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Item Reported by (Phone)")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name ="Lost Date")]
        [DataType(DataType.Date)]
        public DateTime LostDateTime { get; set; }

        public AppUser RecordEnteredBy { get; set; }

        public string Approved { get; set; }

        [Display(Name = "Found Date")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FoundDate { get; set; }


        [Display(Name ="IP Address")]
        public string IPAdress { get; set; }

        public string Active { get; set; }

        [Display(Name = "Record Opened")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [MaxLength(2048)]
        [Display(Name = "Closing Reason")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string ReasonCaseClosed { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Claimed By First Name")]
        public string ClaimerFirstName { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Claimed By Last Name")]
        public string ClaimerLastName { get; set; }

        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Claimed By Email")]
        [Required]
        public string ClaimerEmail { get; set; }
  public AppUser CaseClosedBy { get; set; }

       
        [Display(Name ="Keep Case Open")]
        public bool KeepCaseOpen { get; set; }


    }
}