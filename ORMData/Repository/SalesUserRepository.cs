using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData.Repository
{
    public class SalesUserRepository : Repository<SalesManInfo, long, OMSDbContext>
    {
        public SalesUserRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<SalesManInfo> Set
        {
            get { return _db.SalesManInfos; }
        }

        public List<SalesManInfo> getAllActiveUser()
        {
            return _db.SalesManInfos.Where(p => p.isActive == true).ToList();
        }

        public SalesManInfo getSalesManDetails(string salesManLoginId)
        {
            return _db.SalesManInfos.Where(p => p.isActive == true && p.LoginDomain == salesManLoginId).FirstOrDefault();
        }
    }
}