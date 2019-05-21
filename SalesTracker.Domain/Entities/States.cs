using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class States
    {
        public States()
        {
            Addresses = new HashSet<Addresses>();
            Postcodes = new HashSet<Postcodes>();
        }

        public int Id { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public int? CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Postcodes> Postcodes { get; set; }
    }
}
