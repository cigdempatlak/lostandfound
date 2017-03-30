using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostAndFound.Web.Models
{
    public class ListLostReportItemVM
    {
       public List<LostItem> LostItems { get; set; }

        public ListLostReportItemVM()
        {
            LostItems = new List<LostItem>();
        }
    }

    public class LostItem
    {
        private DateTime dateLost;

        public DateTime DateLost { get { return dateLost; } set { dateLost = value.ToLocalTime(); } }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
    }
}