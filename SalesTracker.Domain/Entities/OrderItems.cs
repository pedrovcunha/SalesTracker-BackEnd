using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class OrderItems
    {
        public int OrderOrderId { get; set; }
        public int ItemItemId { get; set; }

        public virtual Items ItemItem { get; set; }
        public virtual Orders OrderOrder { get; set; }
    }
}
