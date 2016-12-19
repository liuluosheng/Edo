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
using System.Threading.Tasks;
using System.Data.Entity;
using Edo.Service;
using Edo.Web.Model;

namespace Edo.Web.Controllers
{
    public partial class CustomersController
    {
        private readonly BaseService<Region> _regionService;
        public CustomersController(BaseService<Customers> service, BaseService<Region> regionService)
            : base(service)
        {
            _regionService = regionService;
        }
        public override async Task<ActionResult> Edit(CustomersViewModel entity)
        {
            Customers model = _service.Repository.GetByKey(entity.Id);
            var regions = _service.Repository.OtherEntities<Region>();
            foreach (var region in entity.Regions)
            {
                Guid Id = region.Id;
                model.Regions.Add(regions.FirstOrDefault(p => p.Id == Id));
            }
            return Content(GetJsonString(new Result { Success = await _service.Repository.UpdateAsync(model) > 0 }));
        }
    }
}