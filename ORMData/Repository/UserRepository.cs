using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq;

namespace ORMData.Repository
{
    public class UserRepository : Repository<Customers, long, OMSDbContext>
    {
        public UserRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<Customers> Set
        {
            get { return _db.Customers; }
        }

        public List<Customers> getAllUser()
        {
            var userData = _db.Customers.ToList();
            return userData;
        }
    }
}