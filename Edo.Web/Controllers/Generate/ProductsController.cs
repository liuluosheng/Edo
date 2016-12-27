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
	public partial class ProductsController : BaseController<Products, ProductsViewModel>
	{
        public ProductsController(BaseService<Products> service)
        :base(service)
        {
       
        }
        public ActionResult Index()
        {
            return View();
        }
       }
}
