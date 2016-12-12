

using System.ComponentModel.DataAnnotations;
using Edo.Data.Entity.ComponentModel;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;
    [NgTemplate]
    public partial class Categories : EntityBase
    {
        [GridColumn]
        public string CategoryName { get; set; }
        [GridColumn]
        public string Description { get; set; }
        [GridColumn]
        public string Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
