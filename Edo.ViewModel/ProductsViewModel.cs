using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Edo.Data.Entity;

namespace Edo.ViewModels
{
    public class ProductsViewModel : EntityBaseViewModel
    {
        [DisplayName("产品名称")]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
        //public virtual Suppliers Suppliers { get; set; }
    }
}