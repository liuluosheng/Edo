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
    [Form]
    public partial class RegionViewModel : EntityBaseViewModel
    {
       
                [GirdColumn]                  
                [DisplayName("RegionDescription")]
                public virtual String RegionDescription { get; set; }

           
                [JsonIgnore]
                [NavTag("Customers")]
                [Grid]                  
                [DisplayName("Customers")]
                public virtual  ICollection<CustomersViewModel> Customers { get; set; }

            }
}
