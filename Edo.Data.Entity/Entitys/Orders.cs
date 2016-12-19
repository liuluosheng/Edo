
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    [NgTemplate]
    public partial class Orders : EntityBase
    {
        public Guid CustomerID { get; set; }

        [NotMapped, GridColumn(Field = "Customers.CompanyName")]
        public string CustomerName { get { return Customers != null ? Customers.CompanyName : null; } }

        public Guid EmployeeID { get; set; }
        public Guid ShipperID { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        [GridColumn]
        public string ShipName { get; set; }
        [GridColumn]
        public string ShipAddress { get; set; }
        [GridColumn]
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        [Required, GridColumn(Width = 200)]
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        [GridColumn(Width = 200)]
        public DateTime? ShippedDate { get; set; }
        [Select(NameField = "CompanyName")]
        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }
        [Select(NameField = "HomePhone")]
        [ForeignKey("EmployeeID")]
        public virtual Employees Employees { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [Select(NameField = "CompanyName")]
        [ForeignKey("ShipperID")]
        public virtual Shippers Shippers { get; set; }
    }
}
