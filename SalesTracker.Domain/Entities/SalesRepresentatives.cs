using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class SalesRepresentatives
    {
        public SalesRepresentatives()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string JobTitle { get; set; }
        public int? PromotionAgencyId { get; set; }

        public virtual PromotionalAgencies PromotionAgency { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
