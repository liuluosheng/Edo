using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Edo.Data.Entity;
using Edo.IRepository;
using Edo.Repository;
using Edo.Service;
using Serenity;
using Serenity.Abstractions;
using Serenity.Caching;

namespace Edo.Web
{
    public static class AutoFacRegister
    {

        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            builder.RegisterInstance<ILocalCache>(new HttpRuntimeCache()).SingleInstance();
            builder.RegisterInstance<IDistributedCache>(new DistributedCacheEmulator()).SingleInstance();
            builder.RegisterType<EdoDbContext>();
            builder.RegisterGeneric(typeof(BaseService<>)).AsSelf().PropertiesAutowired();
            builder.RegisterGeneric(typeof(BaseRepository<>)).AsSelf().AsImplementedInterfaces().PropertiesAutowired();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}