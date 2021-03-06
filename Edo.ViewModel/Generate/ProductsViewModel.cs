﻿using System;
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
    public partial class ProductsViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("ProductName")]
                public virtual String ProductName { get; set; }
          
                [DisplayName("SupplierName")]
                public virtual String SupplierName { get; set; }
          
                [DisplayName("SupplierID")]
                public virtual Guid SupplierID { get; set; }
          
                [DisplayName("CategoryID")]
                public virtual Guid CategoryID { get; set; }
          
                [DisplayName("QuantityPerUnit")]
                public virtual String QuantityPerUnit { get; set; }
          
                [DisplayName("UnitPrice")]
                public virtual Int16? UnitPrice { get; set; }
          
                [DisplayName("UnitsInStock")]
                public virtual Int16? UnitsInStock { get; set; }
          
                [DisplayName("UnitsOnOrder")]
                public virtual Int16? UnitsOnOrder { get; set; }
          
                [DisplayName("ReorderLevel")]
                public virtual Int16? ReorderLevel { get; set; }
          
                [DisplayName("Discontinued")]
                public virtual Boolean Discontinued { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Categories")]
                public virtual Categories Categories { get; set; }
  
                [IgnoreMap]          
                [DisplayName("OrderDetails")]
                public virtual  ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Suppliers")]
                public virtual Suppliers Suppliers { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 