using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Model
{
    public class InventoryModel
    {
        public long Id { get; set; }
        public string InventoryName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public long ImageInventoryId { get; set; }
        public string Stock_Keeping_Unit { get; set; }
        public string Barcode { get; set; }
        public decimal AvailableQuantity { get; set; }
        public decimal Price { get; set; }
        public bool isActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public List<InventoryAttachmentModel> inventoryAttachmentModel { get; set; }
    }
}