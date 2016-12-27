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
    public partial class UserViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("Name")]
                public virtual String Name { get; set; }
          
                [DisplayName("NickName")]
                public virtual String NickName { get; set; }
          
                [DisplayName("Password")]
                public virtual String Password { get; set; }
          
                [DisplayName("Address")]
                public virtual String Address { get; set; }
          
                [DisplayName("Email")]
                public virtual String Email { get; set; }
          
                [DisplayName("Mobile")]
                public virtual String Mobile { get; set; }
          
                [DisplayName("RegisterDate")]
                public virtual DateTime RegisterDate { get; set; }
          
                [DisplayName("UserType")]
                public virtual UserType UserType { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Roles")]
                public virtual  ICollection<RoleViewModel> Roles { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 