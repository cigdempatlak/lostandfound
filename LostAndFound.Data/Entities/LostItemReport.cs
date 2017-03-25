using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostAndFound.Data.Entities
{
    public class LostItemReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid LostReportItemId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }

        [MaxLength(2048)]
        [Required]
        public string Description { get; set; }

        [Required]
        public TypeOfItem LostItemType { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public Location LostLocation { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime LostDateTimeUTC { get; set; }

        [Required]
        public string IPAdress { get; set; }

        [Required]
        public bool Active { get; set; }
        [Required]
        public DateTime DateCreatedUTC { get; set; }
        [MaxLength(1024)]
        public string Notes { get; set; }

        public LostItemReport()
        {
            Active = true;
            DateCreatedUTC = DateTime.UtcNow;
            LostDateTimeUTC = DateTime.UtcNow;
        }
    }
}
