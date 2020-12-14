using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData.Repository
{
    public class InventoryRepository : Repository<Inventory, long, OMSDbContext>
    {
        public InventoryRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<Inventory> Set
        {
            get { return _db.Inventories; }
        }

        public List<Inventory> getAllInventory()
        {
            return _db.Inventories.ToList();
        }

        public Inventory checkInventoryData(long inventoryId)
        {
            return _db.Inventories.Where(item => item.Id == inventoryId && item.AvailableQuantity != 0).FirstOrDefault();
        }
    }
}