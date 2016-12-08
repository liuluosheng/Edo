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
    public partial class SuppliersViewModel : EntityBaseViewModel
    {
       
                [GirdColumn]                  
                [DisplayName("CompanyName")]
                public virtual String CompanyName { get; set; }

                [GirdColumn]                  
                [DisplayName("ContactName")]
                public virtual String ContactName { get; set; }

                [GirdColumn]                  
                [DisplayName("ContactTitle")]
                public virtual String ContactTitle { get; set; }

                [GirdColumn]                  
                [DisplayName("Address")]
                public virtual String Address { get; set; }

                [GirdColumn]                  
                [DisplayName("City")]
                public virtual String City { get; set; }

                [GirdColumn]                  
                [DisplayName("Region")]
                public virtual String Region { get; set; }

                [GirdColumn]                  
                [DisplayName("PostalCode")]
                public virtual String PostalCode { get; set; }

                [GirdColumn]                  
                [DisplayName("Country")]
                public virtual String Country { get; set; }

                [GirdColumn]                  
                [DisplayName("Phone")]
                public virtual String Phone { get; set; }

                [GirdColumn]                  
                [DisplayName("Fax")]
                public virtual String Fax { get; set; }

                [GirdColumn]                  
                [DisplayName("HomePage")]
                public virtual String HomePage { get; set; }

           
                [JsonIgnore]
                [NavTag("Products")]
                [Grid(ForeignKey ="SupplierID")]                  
                [DisplayName("Products")]
                public virtual  ICollection<ProductsViewModel> Products { get; set; }

            }
}
