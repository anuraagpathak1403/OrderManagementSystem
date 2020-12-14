using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices.Model
{
    public class SalesUserModel
    {
        public long Id { get; set; }
        public string LoginDomain { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNumber { get; set; }
        public bool isActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public long CreatedBy { get; set; }
        public long ModifiedBy { get; set; }
    }
}