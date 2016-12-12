﻿// <autogenerated>
//   This file was generated by T4 code generator GenerateViewModel.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;
using Edo.Data.Entity;
namespace Edo.ViewModels
{
    public partial class ShippersViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("CompanyName")]
                public virtual String CompanyName { get; set; }
          
                [DisplayName("Phone")]
                public virtual String Phone { get; set; }
  
                [JsonIgnore]          
                [DisplayName("Orders")]
                public virtual  ICollection<OrdersViewModel> Orders { get; set; }
   }
}
 