﻿using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class PromotionalAgencies
    {
        public PromotionalAgencies()
        {
            SalesRepresentatives = new HashSet<SalesRepresentatives>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Phone { get; set; }
        public int? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<SalesRepresentatives> SalesRepresentatives { get; set; }
    }
}
