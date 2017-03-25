using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound.Data.Entities
{
    public  class Location
    {
        public bool Active { get; set; }
        public DateTime DateCreatedUTC { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LocationId { get; set; }

         [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Location()
        {
            DateCreatedUTC = DateTime.UtcNow;
            Active = true;
        }

    }
}
