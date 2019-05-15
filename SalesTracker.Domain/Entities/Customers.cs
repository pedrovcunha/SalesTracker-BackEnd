using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }

        public virtual People Person { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
