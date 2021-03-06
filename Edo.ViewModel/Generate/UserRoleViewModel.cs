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
    public partial class UserRoleViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("RoleId")]
                public virtual Guid RoleId { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Role")]
                public virtual Role Role { get; set; }
          
                [DisplayName("UserId")]
                public virtual Guid UserId { get; set; }
  
                [IgnoreMap]          
                [DisplayName("User")]
                public virtual User User { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 