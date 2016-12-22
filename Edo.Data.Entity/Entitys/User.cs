using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity.ComponentModel;
using Edo.Data.Entity.Enum;

namespace Edo.Data.Entity
{
    [NgTemplate]
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        [GridColumn]
        public ColumnType ColumnType { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
