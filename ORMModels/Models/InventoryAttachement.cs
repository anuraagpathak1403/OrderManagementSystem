using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class InventoryAttachement
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }

        [StringLength(600)]
        public String AttachmentPath { get; set; }
        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}