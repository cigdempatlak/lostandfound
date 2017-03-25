using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound.Data.Entities
{
    public class TypeOfItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TypeOfItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool Active { get; set; }
        [Required]
        public DateTime DateCreatedUTC { get; set; }
        [MaxLength(1024)]
        public string Notes { get; set; }

        public TypeOfItem()
        {
            Active = true;
            DateCreatedUTC = DateTime.UtcNow;
        }
    }
}
