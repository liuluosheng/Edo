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
    public partial class UserPermissionViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("UserName")]
                public virtual String UserName { get; set; }
          
                [DisplayName("UserId")]
                public virtual Guid UserId { get; set; }
  
                [IgnoreMap]          
                [DisplayName("User")]
                public virtual User User { get; set; }
          
                [DisplayName("PermissionKey")]
                public virtual String PermissionKey { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 