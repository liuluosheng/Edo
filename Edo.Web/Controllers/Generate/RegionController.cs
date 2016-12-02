﻿// <autogenerated>
//   This file was generated by T4 code generator Generate.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.Entity;
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
    public partial class RegionController : BaseController<Region, RegionViewModel>
    {
        public RegionController(BaseService<Region> service)
            : base(service)
        {

        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> PageCustomers(string itemFilter, int pageIndex, int pageSize, string sort, string filter)
        {
            var obj = _dbset.FirstOrDefault(itemFilter);
            if (obj == null) return HttpNotFound();
            return await PageData<Customers, CustomersViewModel>(obj.Customers.AsQueryable(), sort, filter, pageIndex, pageSize);
        }
        public async Task<ActionResult> Select2Customers(string itemFilter, string field, string q)
        {
            var obj = await _dbset.Where(itemFilter).FirstOrDefaultAsync();
            if (obj == null) return HttpNotFound();
            return await SelectData(obj.Customers.AsQueryable(), field, q);
        }
    }
}