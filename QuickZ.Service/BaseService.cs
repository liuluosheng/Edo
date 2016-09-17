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
    public class BaseService<T> where T : EntityBase
    {
        public readonly IBaseRepository<T> Repository;

        public BaseService(IBaseRepository<T> repository)
        {
            Repository = repository;
        }

    }
}
