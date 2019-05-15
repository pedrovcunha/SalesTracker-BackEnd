using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Postcodes
    {
        public Postcodes()
        {
            Adresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public int? PostCode { get; set; }
        public string Description { get; set; }
        public int? StateId { get; set; }

        public virtual States State { get; set; }
        public virtual ICollection<Addresses> Adresses { get; set; }
    }
}
