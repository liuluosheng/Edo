﻿using System;
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
using Edo.Web.Model;
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
           
      #region Users    
        public async Task<ActionResult> PageUser(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
           var obj = _dbset.Where(itemFilter).SelectMany(p => p.Users);
            return await PageData<User, UserViewModel>(obj, sort, filter, pageIndex, pageSize);    
        }
        public async Task<ActionResult> Select2User(string itemFilter, string field, string q)
        {
            var obj = _dbset.Where(itemFilter).SelectMany(p => p.Users);
            return await SelectData(obj, field, q);       
        }  
        public async Task<ActionResult> DeleteUser(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Users.Remove(_service.Repository.OtherEntities<User>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Role,RoleViewModel>(model) }));
        }  
        public async Task<ActionResult> CreateUser(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Users.Add(_service.Repository.OtherEntities<User>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Role,RoleViewModel>(model)}));
        }  
     #endregion  
     }
}
