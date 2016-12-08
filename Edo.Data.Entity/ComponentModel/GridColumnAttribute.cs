using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Web;
using Edo.Data.Entity.Enum;
using Newtonsoft.Json;

namespace Edo.Data.Entity.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class GirdColumnAttribute : Attribute
    {
        public GirdColumnAttribute()
        {
            Type = ColumnType.Text;
            Width = 150;
            Hide = false;
            Sortable = true;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public ColumnType Type { get; set; }

        /// <summary>
        /// 列字段名称
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 单元格的格式化函数
        /// </summary>
        public object Formatter { get; set; }
        /// <summary>
        /// 返回的JSON数据对应的属性名称
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否排序
        /// </summary>
        public bool Sortable { get; set; }
        /// <summary>
        ///宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hide { get; set; }
        [JsonIgnore]
        public override object TypeId
        {
            get { return base.TypeId; }
        }
    }
}