using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTracker.Domain.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int Id { get; set; }
        public int SalesRepresentativeId { get; set; }
        public int? RetailStoreId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Commission { get; set; }

        public virtual RetailStores RetailStore { get; set; }
        public virtual SalesRepresentatives SalesRepresentative { get; set; }
        public virtual ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
