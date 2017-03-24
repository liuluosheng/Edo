using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity.Enum;

namespace Edo.Data.Entity.ComponentModel
{
    public class GenerateControllerAttribute : Attribute
    {
        public string Title { get; set; }
        /// <summary>
        /// 模块的操作项
        /// </summary>
        public PermissionKey[] PermissionKeys { get; set; }
    }
}
