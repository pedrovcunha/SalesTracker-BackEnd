using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class ItemCategories
    {
        public ItemCategories()
        {
            Items = new HashSet<Items>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
