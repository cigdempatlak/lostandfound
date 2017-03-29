using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound.Data.Entities
{
    public class LostItem
    {
        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime DateCreatedUTC { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LostItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public TypeOfItem LostItemType { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [Required]
        public DateTime FoundDateInUtc { get; set; }

        [Required]
        public Location FoundLocation { get; set; }

        [MaxLength(2048)]
        public string ReasonCaseClosed { get; set; }
        
        public AppUser CaseClosedBy { get; set; }

        public AppUser RecordEnteredBy { get; set; }

        public LostItem()
        {
            DateCreatedUTC = DateTime.UtcNow;
            Active = true;
            FoundDateInUtc = DateTime.UtcNow;
        }
    }
}
