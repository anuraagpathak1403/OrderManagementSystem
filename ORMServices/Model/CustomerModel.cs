using System;
using System.Collections.Generic;

namespace ORMServices.Model
{
    public class CustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public long MobileNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}