using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity
{
    public class User : EntityBase
    {
        public  string Name { get; set; }
        public  string Password { get; set; }       
        public string Address { get; set; }     

        public virtual  ICollection<Role> Roles { get; set; } 
    }
}
