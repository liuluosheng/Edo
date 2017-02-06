using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ViewAttribute : Attribute
    {
        public ViewAttribute(string url)
        {
            Url = url;
        }
        public string Url { get; set; }
    }
}
