

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate]
    public partial class OrderDetails : EntityBase
    {
        public Guid OrderID { get; set; }

        [NotMapped, GridColumn(Field = "Products.ProductName")]
        public string ProductName
        {
            get { return Products.ProductName; }
        }
        public Guid ProductID { get; set; }
        [GridColumn, Required]
        public decimal UnitPrice { get; set; }
        [GridColumn, Required]
        public short Quantity { get; set; }
        [GridColumn]
        public float Discount { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Orders { get; set; }
        [ForeignKey("ProductID"), Select(NameField = "ProductName")]
        public virtual Products Products { get; set; }


    }
}
