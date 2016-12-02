using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity;
using Edo.IRepository;
using Edo.Repository;

namespace Edo.Service
{
   public class UserService:BaseService<User>
    {
       public UserService(IBaseRepository<User> repository) : base(repository)
       {
           
       }        
    }
}
