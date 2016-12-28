
using System;
using Edo.Data.Entity;
using Edo.Data.Entity.Enum;

namespace Edo.Web
{
    /// <summary>
    /// 定义系统中所有的权限KEY
    /// </summary>
    public class PermissionKeys
    {
        public class Customer
        {
            public const string Delete = "Edo:Customer:Delete";
            public const string Modify = "Edo:Customer:Modify";
            public const string View = "Edo:Customer:View";
        }

        public const string General = "Edo:General";

        public static string GetPermissionKey(Type module, PermissionKey permission)
        {
            if (module.BaseType != typeof(EntityBase)) return null;
            return string.Format("Edo:{0}:{1}", module.Name, permission.ToString());
        }
    }
}
