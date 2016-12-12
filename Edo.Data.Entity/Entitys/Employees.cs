
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate]
    public partial class Employees : EntityBase
    {
        [GridColumn]
        public string LastName { get; set; }
        [GridColumn]
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [GridColumn]
        public string Address { get; set; }
        [GridColumn]
        public string City { get; set; }
        [GridColumn]
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
