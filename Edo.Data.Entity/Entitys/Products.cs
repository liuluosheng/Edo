
using System.ComponentModel.DataAnnotations.Schema;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Products : EntityBase
    {
        public string ProductName { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        [ForeignKey("SupplierID")]
        public virtual Suppliers Suppliers { get; set; }
    }
}
