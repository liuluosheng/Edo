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
    [NgTemplate, GenerateController(Title = "系统用户")]
    public class User : EntityBase
    {
        [GridColumn]
        public string Name { get; set; }
        public string NickName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Address { get; set; }
        [GridColumn]
        public string Email { get; set; }
        [GridColumn]
        public string Mobile { get; set; }
        public DateTime RegisterDate { get; set; }
        [GridColumn, Editable(false)]
        public UserType UserType { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<UserPermission> Permissions { get; set; }
    }
}
