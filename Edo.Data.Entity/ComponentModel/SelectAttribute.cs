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
            NameField = "Id";
        }
        public string NameField { get; set; }
    }
}
