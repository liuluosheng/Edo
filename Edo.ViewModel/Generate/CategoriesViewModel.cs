﻿// <autogenerated>
//   This file was generated by T4 code generator Generate.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;
using Edo.Data.Entity;
namespace Edo.ViewModels
{
    [Form("基本信息")]
    public partial class CategoriesViewModel : EntityBaseViewModel
    {
       
           
                              [GirdColumn(Sortable = true, Width = 100)]        
               [DisplayName("CategoryName")]
               public virtual String CategoryName { get; set; }
                 
                              [GirdColumn(Sortable = true, Width = 100)]        
               [DisplayName("Description")]
               public virtual String Description { get; set; }
                 
                              [GirdColumn(Sortable = true, Width = 100)]        
               [DisplayName("Picture")]
               public virtual String Picture { get; set; }
                 
                                [JsonIgnore]
                 [Grid(ForeignKey ="CategoryID")]
                              [GirdColumn(Sortable = true, Width = 100)]        
               [DisplayName("Products")]
               public virtual  ICollection<Products> Products { get; set; }
                 
                              [GirdColumn(Sortable = true, Width = 100)]        
               [DisplayName("CreatedDate")]
               public virtual DateTime CreatedDate { get; set; }
                  }
}
