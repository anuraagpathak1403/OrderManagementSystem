using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class OrderStatus
    {
        [Key]
        [Column("OrderId")]
        public long Id { get; set; }
        [Required]
        [ForeignKey("Inventory")]
        public long InventoryId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal UnitOrder { get; set; }
        public decimal PurchaseAmount { get; set; }
        [ForeignKey("Customers")]
        public long CustomerId { get; set; }
        [ForeignKey("SalesManInfo")]
        public long SalesManLoginDomain { get; set; }
        [ForeignKey("StatusMaster")]
        public long Status { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        //Use of foreign key constrants
        public virtual Customers Customers { get; set; }
        public virtual SalesManInfo SalesManInfo { get; set; }
        public virtual StatusMaster StatusMaster { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}