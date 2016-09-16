

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuickZ.Utility;

namespace QuickZ.Data.Entity
{
    /// <summary>
    /// 可持久化到数据库的数据模型基类
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// </summary>
        protected EntityBase()
        {

            Id = CombHelper.NewComb();
            IsDeleted = false;
            CreatedDate = DateTime.Now;

        }



        #region 属性

        /// <summary>
        /// 获取或设置 实体唯一标识，主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("主键")]
        public Guid Id { get; set; }
        /// <summary>
        /// 获取或设置 是否删除，逻辑上的删除，非物理删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 获取或设置 版本控制标识，用于处理并发
        /// </summary>
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
        #endregion

    }
}