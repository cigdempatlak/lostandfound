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
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Lost Date")]
        [DataType(DataType.Date)]
        public DateTime LostDateTime{ get; set; }

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
        public List<LostLocation> Location { get; set; }
        public Guid SelectedLocationID { get; set; }

        [Required]
        [Display(Name = "Item Type")]
        public List<LostItemType> ItemType { get; set; }
        public Guid SelectedItemType { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        public LostItemReportVM()
        {
            Location = new List<LostLocation>();
            ItemType = new List<LostItemType>();
        }
    }

    public class LostLocation
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
    }

    public class LostItemType
    {
        public Guid Key { get; set; }
        public string Name { get; set; }
    }
}