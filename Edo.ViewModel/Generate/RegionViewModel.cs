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
    public partial class RegionViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("RegionDescription")]
                public virtual String RegionDescription { get; set; }
          
                [DisplayName("RegionType")]
                public virtual ColumnType RegionType { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Customers")]
                public virtual  ICollection<CustomersViewModel> Customers { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 