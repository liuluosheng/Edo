
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    [NgTemplate, GenerateController(Title = "∂©µ•–≈œ¢")]
    public partial class Orders : EntityBase
    {
        public Guid CustomerID { get; set; }

        [NotMapped, GridColumn(Field = "Customers.CompanyName")]
        public string CustomerName { get { return Customers != null ? Customers.CompanyName : null; } }
        [NotMapped]
        public string EmployeesHomePhone { get { return Employees != null ? Employees.HomePhone : null; } }
        [NotMapped, GridColumn(Field = "Shippers.CompanyName")]
        public string ShippersName { get { return Shippers != null ? Shippers.CompanyName : null; } }
        [Required]
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

        [ForeignKey("CustomerID"), Select(ToNameField = "CustomerName", FromNameField = "CompanyName")]
        public virtual Customers Customers { get; set; }

        [ForeignKey("EmployeeID"), Select(ToNameField = "EmployeesHomePhone", FromNameField = "HomePhone")]
        public virtual Employees Employees { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        [ForeignKey("ShipperID"), Select(ToNameField = "ShippersName", FromNameField = "CompanyName")]
        public virtual Shippers Shippers { get; set; }
    }
}
