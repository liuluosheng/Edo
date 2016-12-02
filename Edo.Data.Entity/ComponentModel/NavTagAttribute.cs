using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NavTagAttribute : Attribute
    {
        public NavTagAttribute(string tag)
        {
            Tag = tag;
        }

        public string Tag { get; set; }
    }
}
