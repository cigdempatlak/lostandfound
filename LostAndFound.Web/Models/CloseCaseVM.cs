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

        public string ItemName { get; set; }

        public string Description { get; set; }

        public string LostItemType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LostLocation { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime LostDateTime { get; set; }

        public AppUser RecordEnteredBy { get; set; }

        public bool Approved { get; set; }

        public DateTime? FoundDate{ get; set; }


        public string IPAdress { get; set; }

        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
      
         public string Notes { get; set; }

        [MaxLength(2048)]
        [Display(Name ="Closing Reason")]
        public string ReasonCaseClosed { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="Claimed By First Name")]
        public string ClaimerFirstName { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Claimed By Last Name")]
        public string ClaimerLastName { get; set; }

        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Claimed By Email")]
        public string ClaimerEmail { get; set; }

        public AppUser CaseClosedBy { get; set; }
        public DateTime CaseClosedDate { get; set; }


    }
}