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
    public partial class RoleViewModel : EntityBaseViewModel
    {
       
                [GirdColumn]                  
                [DisplayName("Name")]
                public virtual String Name { get; set; }

           
                [JsonIgnore]
                [NavTag("User")]
                [Grid]                  
                [DisplayName("Users")]
                public virtual  ICollection<UserViewModel> Users { get; set; }

            }
}
