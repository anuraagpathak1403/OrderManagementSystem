using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData.Repository
{
    public class OrderStatusRepository : Repository<OrderStatus, long, OMSDbContext>
    {
        public OrderStatusRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<OrderStatus> Set
        {
            get { return _db.OrderStatuses; }
        }

        public List<OrderStatus> getDetailedData()
        {
            return _db.OrderStatuses.ToList();
        }

        public List<OrderStatus> getPlacedData(long placedId)
        {
            return _db.OrderStatuses.Where(item => item.Status == placedId).ToList();
        }

        public List<OrderStatus> getOrderDetailsByCustomerID(long customerId)
        {
            return _db.OrderStatuses.Where(item => item.CustomerId == customerId).ToList();
        }
    }
}