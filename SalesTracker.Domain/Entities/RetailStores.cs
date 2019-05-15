﻿using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class RetailStores
    {
        public RetailStores()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}