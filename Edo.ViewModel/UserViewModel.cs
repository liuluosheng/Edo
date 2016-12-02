using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.ViewModel
{
    public class UserViewModel
    {
        [DisplayName("姓名")]
        public string Name { get; set; }
    }
}
