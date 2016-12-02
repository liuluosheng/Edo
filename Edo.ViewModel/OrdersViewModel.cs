﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Edo.Data.Entity;
using Edo.Data.Entity.ComponentModel;
using Edo.Data.Entity.Enum;


namespace Edo.ViewModels
{
    [Form("基本信息", "发货人信息", "订单详情")]
    public class OrdersViewModel : EntityBaseViewModel
    {
        /// <summary>
        /// 发货人名称
        /// </summary>
        [DisplayName("发货人名称")]
        [GirdColumn]
        public string ShipName { get; set; }

        /// <summary>
        /// 发货人地址
        /// </summary>
        [DisplayName("发货人地址")]
        [GirdColumn]
        [RegularExpression("/^[a-z0-9_-]{3,16}$/", ErrorMessage = "您的输入不正确")]
        public string ShipAddress { get; set; }

        /// <summary>
        /// 发货人城市
        /// </summary>
        [MaxLength(100)]
        [MinLength(1)]
        [DisplayName("发货人城市")]
        [GirdColumn(Sortable = true)]
        public string ShipCity { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        [Required]
        [DisplayName("订单日期")]
        [GirdColumn(Type = ColumnType.Date, Formatter = "formatterDate", Width = 200)]
        public DateTime? OrderDate { get; set; }

        [DisplayName("客户名称")]
        [GirdColumn(Field = "Customers.CompanyName", Sortable = true)]
        [Select("Customers", "CompanyName", "Id", "CustomerID")]
        public string CustomersCompanyName { get; set; }

        [Field(Ignore = true)]
        public string CustomersCompanyAddress { get; set; }

        [Field(Hidden = true)]
        public string CustomerID { get; set; }

        [NavTag("订单详情")]
        [Grid]
        public ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
    }
}