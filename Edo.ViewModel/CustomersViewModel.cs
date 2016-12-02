using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Edo.Data.Entity;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;

namespace Edo.ViewModels
{
    [Form("基本信息", "区域信息", "订单信息")]
    public class CustomersViewModel : EntityBaseViewModel
    {
        [GirdColumn(Sortable = true)]
        [DisplayName("公司名称")]
        public string CompanyName { get; set; }


        [DisplayName("联系名称")]
        public string ContactName { get; set; }


        [DisplayName("标题")]
        public string ContactTitle { get; set; }


        [GirdColumn(Sortable = true)]
        [DisplayName("地址")]
        public string Address { get; set; }


        [GirdColumn(Sortable = true)]
        [DisplayName("城市")]
        public string City { get; set; }


        [DisplayName("区域描述")]
        public string Region { get; set; }


        [DisplayName("邮编")]
        public string PostalCode { get; set; }


        [GirdColumn(Sortable = true)]
        [DisplayName("国家")]
        public string Country { get; set; }


        [GirdColumn(Sortable = true)]
        [DisplayName("移动电话")]
        public string Phone { get; set; }


        [DisplayName("传真")]
        public string Fax { get; set; }


        [NavTag("订单信息")]
        [JsonIgnore]
        [Grid(ForeignKey = "CustomerID")]
        public virtual ICollection<OrdersViewModel> Orders { get; set; }


        [NavTag("区域信息")]
        [JsonIgnore]
        [Grid(Edit = true)]
        public virtual ICollection<RegionViewModel> Regions { get; set; }
    }
}