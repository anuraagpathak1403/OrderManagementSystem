using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class Customers
    {
        [Key]
        [Column("CustomerId")]
        public long Id { get; set; }
        [StringLength(200)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [StringLength(200)]
        public string EmailAddress { get; set; }
        [Required]
        public long MobileNumber { get; set; }
        [StringLength(500)]
        [Required]
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}