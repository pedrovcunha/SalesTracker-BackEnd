using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Addresses
    {
        public Addresses()
        {
            People = new HashSet<People>();
            PromotionalAgencies = new HashSet<PromotionalAgencies>();
            RetailStores = new HashSet<RetailStores>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public int? PostCodeId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual Postcodes PostCode { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<People> People { get; set; }
        public virtual ICollection<PromotionalAgencies> PromotionalAgencies { get; set; }
        public virtual ICollection<RetailStores> RetailStores { get; set; }
    }
}
