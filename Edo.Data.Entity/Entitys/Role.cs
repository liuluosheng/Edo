using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    [NgTemplate,GenerateView(Title="系统角色")]
    public partial class Role : EntityBase
    {
        [GridColumn]
        public string Name { get; set; }
        [GridColumn]
        public string Describe { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
