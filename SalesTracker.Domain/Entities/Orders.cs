using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public int SalesRepresentativeId { get; set; }
        public int? CustomerId { get; set; }
        public int? RetailStoreId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Commission { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual RetailStores RetailStore { get; set; }
        public virtual SalesRepresentatives SalesRepresentative { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
