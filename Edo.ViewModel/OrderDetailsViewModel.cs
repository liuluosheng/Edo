using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Edo.Data.Entity;
using Edo.Data.Entity.ComponentModel;
using Edo.Data.Entity.Enum;
using Newtonsoft.Json;

namespace Edo.ViewModels
{
    [Form("订单详情")]
    public class OrderDetailsViewModel : EntityBaseViewModel
    {
        [DisplayName("产品名称")]
        [GirdColumn(Sortable = true, Field = "Products.ProductName")]
        [Select("Products", "ProductName", "Id", "ProductID")]
        public string ProductsName { get; set; }

        [Field(Key = true)]
        [DisplayName("订单编号")]
        public int OrderID { get; set; }

        [Field(Key = true)]
        [GirdColumn(Sortable = true, Type = ColumnType.Number)]
        [DisplayName("产品编号")]
        public int ProductID { get; set; }

        [DisplayName("价格")]
        [GirdColumn(Sortable = true, Type = ColumnType.Number)]
        public decimal UnitPrice { get; set; }

        [DisplayName("数量")]
        [GirdColumn(Sortable = true, Type = ColumnType.Number)]
        public short Quantity { get; set; }

        [DisplayName("折扣")]
        [GirdColumn(Sortable = true, Type = ColumnType.Number)]
        public float Discount { get; set; }

        [DisplayName("订单日期")]
        [GirdColumn(Sortable = true, Field = "Orders.OrderDate")]
        public DateTime? OrderDate { get; set; }
        [JsonIgnore]
        [Field(Hidden = true)]
        public virtual Orders Orders { get; set; }
        [JsonIgnore]
        [Field(Hidden = true)]
        public virtual Products Products { get; set; }
    }
}