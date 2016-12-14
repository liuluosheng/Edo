
using System.ComponentModel;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    [NgTemplate]
    public partial class Region : EntityBase
    {
        [GridColumn]
        public string RegionDescription { get; set; }
        [DisplayName("客户信息")]
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
