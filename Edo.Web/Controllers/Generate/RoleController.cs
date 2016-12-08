﻿// <autogenerated>
//   This file was generated by T4 code generator GenerateController.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Edo.Data.Entity;
using Edo.Data.Entity.ComponentModel;
using Edo.ViewModels;
using System.Linq.Dynamic.Core;
using Edo.Service;
using System.Threading.Tasks;
namespace Edo.Web.Controllers
{
	public partial class RoleController : BaseController<Role, RoleViewModel>
	{
        public RoleController(BaseService<Role> service)
        :base(service)
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }
               public async Task<ActionResult> PageUser(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
                var obj = _dbset.FirstOrDefault(itemFilter);
                if (obj == null) return HttpNotFound();
                return await PageData<User, UserViewModel>(obj.Users.AsQueryable(), sort, filter, pageIndex, pageSize);       
        }
        public async Task<ActionResult> Select2User(string itemFilter, string field, string q)
        {
                var obj = _dbset.FirstOrDefault(itemFilter);
                if (obj == null) return HttpNotFound();
                return await SelectData(obj.Users.AsQueryable(), field, q);         
        }       
     	}
}