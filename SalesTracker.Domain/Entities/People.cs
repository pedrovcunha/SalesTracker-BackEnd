using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class People
    {
        public People()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
