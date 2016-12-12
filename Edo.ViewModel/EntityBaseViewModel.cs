using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Edo.Data.Entity.ComponentModel;

namespace Edo.ViewModels
{
    public abstract class EntityBaseViewModel
    {
        public Guid Id { get; set; }
    }
}