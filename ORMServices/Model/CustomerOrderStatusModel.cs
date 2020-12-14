using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Model
{
    public class CustomerOrderStatusModel
    {
        public long OrderID { get; set; }
        public string InventoryName { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal PurchaseAmount { get; set; }
        public decimal UnitOrder { get; set; }
        public string Status { get; set; }
        public DateTime OrderedDate { get; set; }
        public string CustomerFullName { get; set; }
        public string SaleManFullName { get; set; }
        public string CurrentStatus { get; set; }
    }
}