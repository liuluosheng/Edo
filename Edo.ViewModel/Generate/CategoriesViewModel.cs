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
    public partial class CategoriesViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("CategoryName")]
                public virtual String CategoryName { get; set; }
          
                [DisplayName("Description")]
                public virtual String Description { get; set; }
          
                [DisplayName("Picture")]
                public virtual String Picture { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Products")]
                public virtual  ICollection<ProductsViewModel> Products { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 