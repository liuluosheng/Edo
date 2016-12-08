

using System.ComponentModel.DataAnnotations.Schema;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class OrderDetails : EntityBase
    {
        public Guid OrderID { get; set; }

        [NotMapped]
        public string ProductName
        {
            get { return Products.ProductName; }
        }

        public Guid ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Orders { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }


    }
}
