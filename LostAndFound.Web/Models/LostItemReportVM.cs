using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LostAndFound.Web.Models
{
    public class LostItemReportVM
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Item Name", Description = "The name of the lost item")]
        public string ItemName { get; set; }

        [MaxLength(2048)]
        [Required]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
       
        [Required]
        [Display(Name ="Location Lost")]
        public string LostLocation { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

    }
}