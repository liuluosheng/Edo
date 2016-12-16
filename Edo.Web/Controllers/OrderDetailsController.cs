using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Edo.Data.Entity;
using Edo.ViewModels;
using Edo.Web.Model;

namespace Edo.Web.Controllers
{
    public partial class OrderDetailsController
    {
        // GET: OrderDetails


        public override async Task<ActionResult> Create(OrderDetailsViewModel model)
        {
            if (_service.Repository.Entities.Any(p => p.OrderID == model.OrderID && p.ProductID == model.ProductID))
                return Content(GetJsonString(new Result { Success = false, Message = "重复的产品信息！" }));
            return await base.Create(model);
        }
        public override async Task<ActionResult> Edit(OrderDetailsViewModel model)
        {
            if (_service.Repository.Entities.Any(p => p.OrderID == model.OrderID && p.ProductID == model.ProductID && p.Id != model.Id))
                return Content(GetJsonString(new Result { Success = false, Message = "重复的产品信息！" }));
            return await base.Edit(model);
        }
    }
}