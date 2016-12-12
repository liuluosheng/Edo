

using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate]
    public partial class Suppliers : EntityBase
    {
        [GridColumn]
        public string CompanyName { get; set; }
        [GridColumn]
        public string ContactName { get; set; }
        [GridColumn]
        public string ContactTitle { get; set; }
        [GridColumn]
        public string Address { get; set; }
        [GridColumn]
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
