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
    [NgTemplate, GenerateController(Title = "用户权限")]
    public class UserPermission : EntityBase
    {
        [NotMapped, GridColumn(Field = "User.Name")]
        public string UserName { get { return User != null ? User.Name : null; } }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [GridColumn]
        public string PermissionKey { get; set; }

    }
}
