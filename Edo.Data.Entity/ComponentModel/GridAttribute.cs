using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GridAttribute : Attribute
    {
        public GridAttribute()
        {
            Edit = true;
            Delete = true;
        
        }
        public bool Edit { get; set; }

        public bool Delete { get; set; }

    }
}
