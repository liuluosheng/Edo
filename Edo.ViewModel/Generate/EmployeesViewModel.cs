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
    public partial class EmployeesViewModel : EntityBaseViewModel
    {     
                  
                [DisplayName("LastName")]
                public virtual String LastName { get; set; }
          
                [DisplayName("FirstName")]
                public virtual String FirstName { get; set; }
          
                [DisplayName("Title")]
                public virtual String Title { get; set; }
          
                [DisplayName("TitleOfCourtesy")]
                public virtual String TitleOfCourtesy { get; set; }
          
                [DisplayName("BirthDate")]
                public virtual DateTime? BirthDate { get; set; }
          
                [DisplayName("HireDate")]
                public virtual DateTime? HireDate { get; set; }
          
                [DisplayName("Address")]
                public virtual String Address { get; set; }
          
                [DisplayName("City")]
                public virtual String City { get; set; }
          
                [DisplayName("Region")]
                public virtual String Region { get; set; }
          
                [DisplayName("PostalCode")]
                public virtual String PostalCode { get; set; }
          
                [DisplayName("Country")]
                public virtual String Country { get; set; }
          
                [DisplayName("HomePhone")]
                public virtual String HomePhone { get; set; }
          
                [DisplayName("Extension")]
                public virtual String Extension { get; set; }
          
                [DisplayName("Photo")]
                public virtual Byte[] Photo { get; set; }
          
                [DisplayName("Notes")]
                public virtual String Notes { get; set; }
          
                [DisplayName("ReportsTo")]
                public virtual Int32? ReportsTo { get; set; }
          
                [DisplayName("PhotoPath")]
                public virtual String PhotoPath { get; set; }
  
                [IgnoreMap]          
                [DisplayName("Orders")]
                public virtual  ICollection<OrdersViewModel> Orders { get; set; }
          
                [DisplayName("Timestamp")]
                public virtual Byte[] Timestamp { get; set; }
   }
}
 