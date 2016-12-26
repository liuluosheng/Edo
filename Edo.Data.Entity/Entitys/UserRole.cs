using System;
using System.ComponentModel.DataAnnotations.Schema;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    [NgTemplate]
    public class UserRole : EntityBase
    {

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
