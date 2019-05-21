using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class OrderProducts
    {
        public int OrderOrderId { get; set; }
        public int ProductProductId { get; set; }

        public virtual Orders OrderOrder { get; set; }
        public virtual Products ProductProduct { get; set; }
    }
}
