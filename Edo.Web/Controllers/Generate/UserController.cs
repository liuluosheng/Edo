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
using Edo.Web.Model;
namespace Edo.Web.Controllers
{
	public partial class UserController : BaseController<User, UserViewModel>
	{
        public UserController(BaseService<User> service)
        :base(service)
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }
           
      #region Roles    
        public async Task<ActionResult> PageRole(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
           var obj = _dbset.Where(itemFilter).SelectMany(p => p.Roles);
            return await PageData<Role, RoleViewModel>(obj, sort, filter, pageIndex, pageSize);    
        }
        public async Task<ActionResult> Select2Role(string itemFilter, string field, string q)
        {
            var obj = _dbset.Where(itemFilter).SelectMany(p => p.Roles);
            return await SelectData(obj, field, q);       
        }  
        public async Task<ActionResult> DeleteRole(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Roles.Remove(_service.Repository.OtherEntities<Role>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<User,UserViewModel>(model) }));
        }  
        public async Task<ActionResult> CreateRole(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Roles.Add(_service.Repository.OtherEntities<Role>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<User,UserViewModel>(model)}));
        }  
     #endregion  
           public override async Task<ActionResult> Edit([Bind(Exclude="UserType")] UserViewModel entity)
        {
            return await base.Edit(entity);
        }
}
}
