using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Model
{
    public class OrderStatusModel
    {
        public long Id { get; set; }
        public long InventoryId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal UnitOrder { get; set; }
        public long CustomerId { get; set; }
        public long SalesManLoginDomain { get; set; }
        public long Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
        public string CustomerFullName { get; set; }
        public string SalesManFullName { get; set; }
        public string CurrentStatus { get; set; }
        public string InventoryName { get; set; }
        public List<CustomerOrderStatusModel> customerOrderStatusModel { get; set; }
    }
}