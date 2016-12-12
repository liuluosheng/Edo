using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Edo.Data.Entity;
using Edo.Data.Entity.ComponentModel;
using Newtonsoft.Json;
using Serenity;
using Serenity.Abstractions;
using Serenity.Localization;
using System.Linq.Dynamic.Core;
using AutoMapper;
using Edo.Data.Entity.Enum;
using Edo.Service;
using Newtonsoft.Json.Converters;
using Edo.ViewModels;

namespace Edo.Web.Controllers
{


    public class HomeController : BaseController<Orders, OrdersViewModel>
    {
        public HomeController(BaseService<Orders> orders)
            : base(orders)
        {

        }
        public ActionResult Index()
        {
            //JsonLocalTextRegistration.AddFromFilesInFolder(HostingEnvironment.MapPath("~/Common/"));       
            //var registry = (LocalTextRegistry)Dependency.Resolve<ILocalTextRegistry>();
            //string languageId = CultureInfo.CurrentUICulture.Name.TrimToNull() ?? "invariant";
            //var data = registry.GetAllAvailableTextsInLanguage(languageId, false);

            // RuntimeTextTemplate template = new RuntimeTextTemplate();
            //  string content = template.TransformText();
            //如果有汉字，需要设置编码格式
            //System.IO.File.WriteAllText(Server.MapPath("~/scripts/common/Q.LT.ts"), content, Encoding.UTF8);
            Dictionary<string, List<PropertyInfo>> props = new Dictionary<string, List<PropertyInfo>>
            {
                {"", new List<PropertyInfo> {}}
            };
            return View();
        }

        public void GetSlickColumnOption()
        {

            var types = Assembly.GetAssembly(typeof(EntityBaseViewModel)).GetTypes();
            var baseType = typeof(EntityBaseViewModel);

            Dictionary<string, List<GridColumnAttribute>> results = new Dictionary<string, List<GridColumnAttribute>>();
            foreach (var type in types)
            {
                var options = new List<GridColumnAttribute>();
                if (type.BaseType != null && type.BaseType == baseType)
                {
                    foreach (var propertyInfo in type.GetProperties())
                    {
                        var data = propertyInfo.GetCustomAttributes<GridColumnAttribute>().FirstOrDefault();
                        if (data != null)
                        {
                            data.Field = data.Field ?? propertyInfo.Name;
                            if (propertyInfo.PropertyType == typeof(DateTime) || propertyInfo.PropertyType == typeof(DateTime?))
                            {
                                data.Type = ColumnType.Date;
                            }
                            if (propertyInfo.PropertyType == typeof(Boolean) || propertyInfo.PropertyType == typeof(Boolean?))
                            {
                                data.Type = ColumnType.Bool;
                            }
                            if (string.IsNullOrEmpty(data.Name))
                            {
                                var displayName = propertyInfo.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();
                                data.Name = displayName != null ? displayName.DisplayName : propertyInfo.Name;
                            }
                            data.Id = propertyInfo.Name;
                            options.Add(data);
                        }
                    }
                    results.Add(type.Name.Replace("ViewModel", ""), options);
                }
            }
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
            };
            settings.Converters.Add(new StringEnumConverter());
            string returns = Newtonsoft.Json.JsonConvert.SerializeObject(new { GridColumnOption = results }, settings);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> GetOrderDetailPage(int id, int pageIndex, int pageSize, string sort, string filter)
        {
            using (EdoDbContext db = new EdoDbContext())
            {
                var dbset = db.Orders.Find(id).OrderDetails.AsQueryable();
                return await PageData<OrderDetails, OrderDetailsViewModel>(dbset, sort, filter, pageIndex, pageSize);
            }
        }




    }
}