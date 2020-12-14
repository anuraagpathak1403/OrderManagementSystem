using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class SalesManInfo
    {
        [Key]
        [Column("UserId")]
        public long Id { get; set; }
        [StringLength(200)]
        [Required]
        public string LoginDomain { get; set; }
        [StringLength(200)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public long MobileNumber { get; set; }
        public bool isActive { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
        
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}