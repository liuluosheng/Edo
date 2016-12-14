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
            RowEdit = true;
            RowDelete = true;
        }
        public bool RowEdit { get; set; }

        public bool RowDelete { get; set; }


    }
}
