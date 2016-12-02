
namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Region : EntityBase
    {
        public string RegionDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
