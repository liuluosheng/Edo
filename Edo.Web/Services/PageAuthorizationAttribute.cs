using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Edo.Data.Entity;
using Edo.Data.Entity.Enum;
using Edo.Service;

namespace Edo.Web
{
    public class PageAuthorizationAttribute : AuthorizeAttribute
    {
        private string[] _permissions;
        public BaseService<User> UserService { get; set; }

        public PageAuthorizationAttribute(params string[] permissions)
        {
            _permissions = permissions;
        }

        public PageAuthorizationAttribute(Type module, PermissionKey permission)
        {
            _permissions = module.BaseType != typeof(EntityBase) ? null : new[] { string.Format("Edo:{0}:{1}", module.Name, permission) };
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext) || !httpContext.User.Identity.IsAuthenticated)
                return false;
            User currentUser = CacheHelper.Get<User>(httpContext.User.Identity.Name);
            currentUser = currentUser ?? UserService.Repository.GetByKey(Guid.Parse(httpContext.User.Identity.Name));
            if (currentUser == null) return false;
            CacheHelper.Insert(httpContext.User.Identity.Name, currentUser);
            return currentUser.Permissions.Any(p => _permissions.Contains(p.PermissionKey));
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult(FormsAuthentication.LoginUrl +
                    "?returnUrl=" + Uri.EscapeDataString(HttpContext.Current.Request.Url.PathAndQuery) +
                    "&denied=1");
                return;
            }

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}