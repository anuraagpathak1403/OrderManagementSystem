
using ORMModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORMData.Repository
{
    public class InventoryAttachmentRepository : Repository<InventoryAttachement, long, OMSDbContext>
    {
        public InventoryAttachmentRepository(OMSDbContext db) : base(db)
        {
        }
        protected override DbSet<InventoryAttachement> Set
        {
            get { return _db.InventoryAttachements; }
        }

        public List<InventoryAttachement> getAllAttachement(long imageInventoryId)
        {
            return _db.InventoryAttachements.Where(p => p.Id == imageInventoryId).ToList();
        }

        public object DeleteFile(long attachementId)
        {
            var deleteFile = _db.InventoryAttachements.SingleOrDefault(x => x.Id == attachementId);
            _db.InventoryAttachements.Remove(deleteFile);
            _db.SaveChanges();
            return deleteFile;
        }
    }
}