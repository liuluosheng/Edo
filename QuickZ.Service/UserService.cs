using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickZ.Data.Entity;
using QuickZ.IRepository;
using QuickZ.Repository;

namespace QuickZ.Service
{
   public class UserService:BaseService<User>
    {
       public UserService(IBaseRepository<User> repository) : base(repository)
       {
           
       }        
    }
}
