using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;

namespace Edo.ViewModels
{
    [Form]
    public class RegionViewModel1
    {
        [GirdColumn(Sortable = true, Width = 500)]
        [DisplayName("区域描述")]
        public string RegionDescription { get; set; }

        [NavTag("客户信息")]
        [JsonIgnore]
        [Grid]
        public virtual ICollection<CustomersViewModel> Customers { get; set; }
    }
}