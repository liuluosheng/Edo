using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SelectAttribute : Attribute
    {
        public SelectAttribute()
        {
        }
        /// <summary>
        /// 选择的行绑定的名称到表单实体的列
        /// </summary>
        public string FromNameField { get; set; }
        /// <summary>
        /// 选择的行要绑定的名称列
        /// </summary>
        public string ToNameField { get; set; }
    }
}
