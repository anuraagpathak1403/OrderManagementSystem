using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMModels.Models
{
    public class StatusMaster
    {
        [Key]
        [Column("StatusId")]
        public long Id { get; set; }
        public string StatusName { get; set; }
    }
}