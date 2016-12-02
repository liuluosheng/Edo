using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Edo.Data.Entity;
using Serenity;
using Serenity.Abstractions;
using Serenity.Caching;
using Serenity.Localization;

namespace Edo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoFacRegister.Register();
            AutoMapperConfig.Initialize();
            Database.SetInitializer(new CreateDatabaseIfNotExists<EdoDbContext>());

            if (!Dependency.HasResolver)
            {
                var container = new MunqContainer();
                Dependency.SetResolver(container);
                var registrar = Dependency.Resolve<IDependencyRegistrar>();
                registrar.RegisterInstance<ILocalTextRegistry>(new LocalTextRegistry());

            }
            CommonInitialization.Run();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


    }
}
