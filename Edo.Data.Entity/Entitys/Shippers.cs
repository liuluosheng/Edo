
namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Shippers : EntityBase
    {

        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
