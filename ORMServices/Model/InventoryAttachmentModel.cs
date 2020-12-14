using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Model
{
    public class InventoryAttachmentModel
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public String AttachmentPath { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}