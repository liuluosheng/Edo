using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NavAttribute : Attribute
    {
        public NavAttribute(params string[] tags)
        {
            Tags = tags;

        }
        public string[] Tags { get; set; }
    }
}
