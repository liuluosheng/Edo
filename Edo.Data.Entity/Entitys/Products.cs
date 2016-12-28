
using System.ComponentModel.DataAnnotations.Schema;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate, GenerateController(Title = "产品信息")]
    public partial class Products : EntityBase
    {
        [GridColumn]
        public string ProductName { get; set; }
        [NotMapped, GridColumn(Field = "Suppliers.CompanyName")]
        public string SupplierName
        {
            get { return Suppliers != null ? Suppliers.CompanyName : null; }
        }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        [GridColumn]
        public short? UnitPrice { get; set; }
        [GridColumn]
        public short? UnitsInStock { get; set; }
        [GridColumn]
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
