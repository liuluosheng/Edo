
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Edo.Data.Entity.ComponentModel;
using Edo.Data.Entity.Enum;

namespace Edo.Data.Entity
{
    using System;
    using System.Collections.Generic;

    [NgTemplate, GenerateController(Title = "������Ϣ")]
    public partial class Region : EntityBase
    {
        [GridColumn]
        public string RegionDescription { get; set; }
        [Required]
        public ColumnType RegionType { get; set; }
        [DisplayName("�ͻ���Ϣ")]
        public virtual ICollection<Customers> Customers { get; set; }

    }
}
