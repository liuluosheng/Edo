using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edo.Data.Entity;
using Edo.Service;
using Edo.ViewModels;

namespace Edo.Web.Controllers
{
    public class ProductsController : BaseController<Products, ProductsViewModel>
    {
        // GET: Products
        public ProductsController(BaseService<Products> service)
            : base(service)
        {
        }
    }
}