using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Edo.Data.Entity;
using Newtonsoft.Json;
using System.Reflection;
using System.Threading.Tasks;
using Edo.Service;
using Edo.ViewModels;
using Edo.Web.Model;
using Newtonsoft.Json.Converters;

namespace Edo.Web.Controllers
{
    public abstract class BaseController<T, TK> : AsyncController
        where T : EntityBase
        where TK : EntityBaseViewModel
    {
        protected BaseService<T> _service;
        protected readonly IQueryable<T> _dbset;
        protected BaseController(BaseService<T> service)
        {
            _service = service;
            _dbset = service.Repository.TrackEntities;
        }

        public virtual async Task<ActionResult> Edit(TK entity)
        {
            return Content(JsonConvert.SerializeObject(new Result { Success = await _service.Repository.UpdateAsync(Mapper.Map<TK, T>(entity)) > 0, Obj = entity }));
        }
        public virtual async Task<ActionResult> Create(TK entity)
        {
            return Content(JsonConvert.SerializeObject(new Result { Success = await _service.Repository.InsertAsync(Mapper.Map<TK, T>(entity)) > 0, Obj = entity }));
        }
        public virtual async Task<ActionResult> Delete(TK entity)
        {
            return Content(JsonConvert.SerializeObject(new Result { Success = await _service.Repository.DeleteAsync(entity.Id) > 0 }));
        }
        public virtual Task<ActionResult> Select2(string field, string q)
        {
            return SelectData(_dbset, field, q);
        }
        public virtual Task<ActionResult> Select(string field, string value, string q)
        {

            string select = string.Format("new({0} as name, {1} as code)", field, value);
            return SelectData(_dbset, select, q);

        }
        public virtual Task<ActionResult> Page(int pageIndex, int pageSize, string sort, string filter)
        {
            return PageData<T, TK>(_dbset, sort, filter, pageIndex, pageSize);
        }


        protected async Task<ActionResult> PageData<F, TF>(IQueryable<F> sources, string sort, string q, int pageIndex = 1, int pageSize = 30)
        {
            if (!string.IsNullOrEmpty(q))
                sources = sources.Where(q);
            if (!string.IsNullOrEmpty(sort))
                sources = sources.OrderBy(sort);
            var data = Mapper.Map<List<F>, List<TF>>(await sources.Page(pageIndex, pageSize).ToListAsync());
            return Content(JsonConvert.SerializeObject(new { data, total = sources.Count() }, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" }));
        }
        protected async Task<ActionResult> SelectData<F>(IQueryable<F> sources, string select, string q)
        {
            if (!string.IsNullOrEmpty(q))
                sources = sources.Where(q);
            var items = await sources.Select(select).Distinct().ToListAsync();
            return Content(JsonConvert.SerializeObject(new { items, total = items.Count },
                new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" }));
        }
    }
}