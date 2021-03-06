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
    public partial class OrdersViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("CustomerID")]
                public virtual Guid CustomerID { get; set; }
          
                [DisplayName("CustomerName")]
                public virtual String CustomerName { get; set; }
          
                [DisplayName("EmployeesHomePhone")]
                public virtual String EmployeesHomePhone { get; set; }
          
                [DisplayName("ShippersName")]
                public virtual String ShippersName { get; set; }
          
                [DisplayName("EmployeeID")]
                public virtual Guid EmployeeID { get; set; }
          
                [DisplayName("ShipperID")]
                public virtual Guid ShipperID { get; set; }
          
                [DisplayName("ShipVia")]
                public virtual Int32? ShipVia { get; set; }
          
                [DisplayName("Freight")]
                public virtual Decimal? Freight { get; set; }
          
                [DisplayName("ShipName")]
                public virtual String ShipName { get; set; }
          
                [DisplayName("ShipAddress")]
                public virtual String ShipAddress { get; set; }
          
                [DisplayName("ShipCity")]
                public virtual String ShipCity { get; set; }
          
                [DisplayName("ShipRegion")]
                public virtual String ShipRegion { get; set; }
          
                [DisplayName("ShipPostalCode")]
                public virtual String ShipPostalCode { get; set; }
          
                [DisplayName("ShipCountry")]
                public virtual String ShipCountry { get; set; }
          
                [DisplayName("OrderDate")]
                public virtual DateTime? OrderDate { get; set; }
          
                [DisplayName("RequiredDate")]
                public virtual DateTime? RequiredDate { get; set; }
          
                [DisplayName("ShippedDate")]
                public virtual DateTime? ShippedDate { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Customers")]
                public virtual Customers Customers { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Employees")]
                public virtual Employees Employees { get; set; }
  
                [IgnoreMap]          
                [DisplayName("OrderDetails")]
                public virtual  ICollection<OrderDetailsViewModel> OrderDetails { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Shippers")]
                public virtual Shippers Shippers { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 