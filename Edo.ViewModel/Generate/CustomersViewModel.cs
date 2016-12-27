using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;
using Edo.Data.Entity;
using AutoMapper;
using Edo.Data.Entity.Enum;
namespace Edo.ViewModels
{
    public partial class CustomersViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("CompanyName")]
                public virtual String CompanyName { get; set; }
          
                [DisplayName("ContactName")]
                public virtual String ContactName { get; set; }
          
                [DisplayName("ContactTitle")]
                public virtual String ContactTitle { get; set; }
          
                [DisplayName("Address")]
                public virtual String Address { get; set; }
          
                [DisplayName("City")]
                public virtual String City { get; set; }
          
                [DisplayName("Region")]
                public virtual String Region { get; set; }
          
                [DisplayName("PostalCode")]
                public virtual String PostalCode { get; set; }
          
                [DisplayName("Country")]
                public virtual String Country { get; set; }
          
                [DisplayName("Phone")]
                public virtual String Phone { get; set; }
          
                [DisplayName("Fax")]
                public virtual String Fax { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Orders")]
                public virtual  ICollection<OrdersViewModel> Orders { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Regions")]
                public virtual  ICollection<RegionViewModel> Regions { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 