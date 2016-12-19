using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Edo.Data.Entity;

namespace Edo.Repository.EntityRepository
{
    public class CustomersRepository : BaseRepository<Customers>
    {
        private EdoDbContext _db;
        public CustomersRepository(EdoDbContext db)
            : base(db)
        {
            
        }

  
    }
}
