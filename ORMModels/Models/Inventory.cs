using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class Inventory
    {
        [Key]
        [Column("InventoryId")]
        public long Id { get; set; }
        [StringLength(300)]
        [Required]
        public string InventoryName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public long ImageInventoryId { get; set; }
        [MaxLength(50)]
        public string Stock_Keeping_Unit { get; set; }
        [MaxLength(15)]
        public string Barcode { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}