
using System.ComponentModel.DataAnnotations.Schema;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Orders : EntityBase
    {
        public Guid CustomerID { get; set; }
        public Guid EmployeeID { get; set; }
        public Guid ShipperID { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employees Employees { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [ForeignKey("ShipperID")]
        public virtual Shippers Shippers { get; set; }
    }
}
