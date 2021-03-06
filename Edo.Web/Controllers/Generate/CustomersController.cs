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
	public partial class CustomersController : BaseController<Customers, CustomersViewModel>
	{
        public CustomersController(BaseService<Customers> service)
        :base(service)
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }
           
      #region Regions    
        public async Task<ActionResult> PageRegion(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
           var obj = _dbset.Where(itemFilter).SelectMany(p => p.Regions);
            return await PageData<Region, RegionViewModel>(obj, sort, filter, pageIndex, pageSize);    
        }
        public async Task<ActionResult> Select2Region(string itemFilter, string field, string q)
        {
            var obj = _dbset.Where(itemFilter).SelectMany(p => p.Regions);
            return await SelectData(obj, field, q);       
        }  
        public async Task<ActionResult> DeleteRegion(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Regions.Remove(_service.Repository.OtherEntities<Region>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Customers,CustomersViewModel>(model) }));
        }  
        public async Task<ActionResult> CreateRegion(Guid id,Guid itemId)
        {
            var model = _service.Repository.GetByKey(id);
            model.Regions.Add(_service.Repository.OtherEntities<Region>().FirstOrDefault(p => p.Id == itemId));
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 ,Obj=AutoMapper.Mapper.Map<Customers,CustomersViewModel>(model)}));
        }  
     #endregion  
     }
}
