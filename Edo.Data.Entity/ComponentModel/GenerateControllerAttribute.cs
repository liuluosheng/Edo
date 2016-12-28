using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    public class GenerateControllerAttribute : Attribute
    {
        public string Title { get; set; }
    }
}
