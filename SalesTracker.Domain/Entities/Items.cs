using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Items
    {
        public Items()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? CategoryId { get; set; }
        public string BrandName { get; set; }

        public virtual ItemCategories Category { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
