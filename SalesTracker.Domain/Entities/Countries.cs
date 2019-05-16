using System;
using System.Collections.Generic;

namespace SalesTracker.Domain.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            Addresses = new HashSet<Addresses>();
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<States> States { get; set; }
    }
}
