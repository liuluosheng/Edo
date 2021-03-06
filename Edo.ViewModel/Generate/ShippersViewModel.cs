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
    public partial class ShippersViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("CompanyName")]
                public virtual String CompanyName { get; set; }
          
                [DisplayName("Phone")]
                public virtual String Phone { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Orders")]
                public virtual  ICollection<OrdersViewModel> Orders { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 