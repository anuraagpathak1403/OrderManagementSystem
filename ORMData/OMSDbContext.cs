using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData
{
    public class OMSDbContext : DbContext
    {
        public OMSDbContext()
                        : base("name=ORSConnection")
        {

        }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryAttachement> InventoryAttachements { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<SalesManInfo> SalesManInfos { get; set; }
        public virtual DbSet<StatusMaster> StatusMasters { get; set; }
    }
}