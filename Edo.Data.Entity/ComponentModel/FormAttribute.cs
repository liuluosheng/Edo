using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    public class FormAttribute : Attribute
    {
        public FormAttribute(params string[] navTags)
        {
            NavTags = navTags;

        }
        public string[] NavTags { get; set; }
    }
}
