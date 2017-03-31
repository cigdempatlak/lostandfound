using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LostAndFound.Web.Models
{
    public class ListLostReportItemVM
    {
        public List<LostItem> LostItems { get; set; }

        [Display(Name ="Search")]
        public string SearchItemName { get; set; }
        [Display(Name ="Active Only")]
        public bool SearchActiveOnly { get; set; }

        public ListLostReportItemVM()
        {
            LostItems = new List<LostItem>();
            SearchActiveOnly = true;
        }
    }

    public class LostItem
    {
        private DateTime dateLost;

        public Guid ItemId { get; set; }

        public DateTime DateLost { get { return dateLost; } set { dateLost = value.ToLocalTime(); } }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
    }
}