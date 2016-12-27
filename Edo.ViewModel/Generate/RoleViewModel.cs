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
    public partial class RoleViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("Name")]
                public virtual String Name { get; set; }
          
                [DisplayName("Describe")]
                public virtual String Describe { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Users")]
                public virtual  ICollection<UserViewModel> Users { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 