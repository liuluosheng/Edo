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
        protected readonly BaseService<T> _service;
        protected readonly IQueryable<T> _dbset;

        protected BaseController(BaseService<T> service)
        {
            _service = service;
            _dbset = service.Repository.Entities;
        }

        public virtual async Task<ActionResult> Edit(TK entity)
        {
           
            T model = Mapper.Map<TK, T>(entity);
            Mapper.Map<T, T>(model);
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0, Obj = Mapper.Map<T, TK>(model) }));
        }
        public virtual async Task<ActionResult> Create(TK entity)
        {
            T model = Mapper.Map<TK, T>(entity);
            return Content(GetJsonString(new Result { Success = await _service.Repository.InsertAsync(Mapper.Map<TK, T>(entity)) > 0, Obj = Mapper.Map<T, TK>(model) }));
        }
        public virtual async Task<ActionResult> Delete(TK entity)
        {
            return Content(GetJsonString(new Result { Success = await _service.Repository.DeleteAsync(entity.Id) > 0 }));
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
            return Content(GetJsonString(new { data, total = sources.Count() }));
        }
        protected async Task<ActionResult> SelectData<F>(IQueryable<F> sources, string select, string q)
        {
            if (!string.IsNullOrEmpty(q))
                sources = sources.Where(q);
            var items = await sources.Select(select).Distinct().ToListAsync();
            return Content(GetJsonString(new { items, total = items.Count }));
        }

        protected string GetJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" } },
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });
        }
    }
}