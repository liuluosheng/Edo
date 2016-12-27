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
    public partial class OrderDetailsViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("OrderID")]
                public virtual Guid OrderID { get; set; }
          
                [DisplayName("ProductName")]
                public virtual String ProductName { get; set; }
          
                [DisplayName("ProductID")]
                public virtual Guid ProductID { get; set; }
          
                [DisplayName("UnitPrice")]
                public virtual Decimal UnitPrice { get; set; }
          
                [DisplayName("Quantity")]
                public virtual Int16 Quantity { get; set; }
          
                [DisplayName("Discount")]
                public virtual Single Discount { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Orders")]
                public virtual Orders Orders { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Products")]
                public virtual Products Products { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 