using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData.Repository
{
    public class StatusMasterRepository : Repository<StatusMaster, long, OMSDbContext>
    {
        public StatusMasterRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<StatusMaster> Set
        {
            get { return _db.StatusMasters; }
        }

        public List<StatusMaster> readAllData()
        {
            return _db.StatusMasters.ToList();
        }
    }
}