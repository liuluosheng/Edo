
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate,GenerateController(Title="发货人信息")]
    public partial class Shippers : EntityBase
    {
        [GridColumn]
        public string CompanyName { get; set; }
        [GridColumn]
        public string Phone { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
