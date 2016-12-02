

using System.ComponentModel.DataAnnotations;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Categories : EntityBase
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
