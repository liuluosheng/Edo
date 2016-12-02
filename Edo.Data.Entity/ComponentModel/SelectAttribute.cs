using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SelectAttribute : Attribute
    {
        public SelectAttribute(string typeName, string nameField, string valueField, string bindField)
        {
            NameField = nameField;
            ValueField = valueField;
            Type = typeName;
            BindField = bindField;

        }
        public string Type { get; set; }
        public string NameField { get; set; }
        public string ValueField { get; set; }
        public string BindField { get; set; }
    }
}
