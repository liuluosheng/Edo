using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity;
using Edo.IRepository;
using Edo.Repository;
using System.Linq.Dynamic.Core;
namespace Edo.Service
{
    public class BaseService<T> where T : EntityBase
    {
        public readonly IBaseRepository<T> Repository;

        public BaseService(IBaseRepository<T> repository)
        {
            Repository = repository;
        }
    }
}
