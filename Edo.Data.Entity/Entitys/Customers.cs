
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate, GenerateController(Title = "客户信息")]
    public partial class Customers : EntityBase
    {
        [GridColumn]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        [GridColumn]
        public string Address { get; set; }
        [GridColumn]
        public string City { get; set; }
        [GridColumn]
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [GridColumn]
        public string Phone { get; set; }
        public string Fax { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}
