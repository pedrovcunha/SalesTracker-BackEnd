using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Postcodes
    {
        public Postcodes()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public int? PostCode { get; set; }
        public string Suburb { get; set; }
        public int? StateId { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public virtual States State { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
