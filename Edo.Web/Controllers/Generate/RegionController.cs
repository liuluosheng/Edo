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
	public partial class RegionController : BaseController<Region, RegionViewModel>
	{
        public RegionController(BaseService<Region> service)
        :base(service)
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }
           
      #region Customers    
        public async Task<ActionResult> PageCustomers(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
           var obj = _dbset.Where(itemFilter).SelectMany(p => p.Customers);
            return await PageData<Customers, CustomersViewModel>(obj, sort, filter, pageIndex, pageSize);    
        }
        public async Task<ActionResult> Select2Customers(string itemFilter, string field, string q)
        {
            var obj = _dbset.Where(itemFilter).SelectMany(p => p.Customers);
            return await SelectData(obj, field, q);       
        }  
        public async Task<ActionResult> DeleteCustomers(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Customers.Remove(_service.Repository.OtherEntities<Customers>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Region,RegionViewModel>(model) }));
        }  
        public async Task<ActionResult> CreateCustomers(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Customers.Add(_service.Repository.OtherEntities<Customers>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Region,RegionViewModel>(model)}));
        }  
     #endregion  
     }
}
