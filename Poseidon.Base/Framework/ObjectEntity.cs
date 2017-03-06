using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 实体对象类
    /// </summary>
    public abstract class ObjectEntity : BaseEntity
    {
        #region Property
        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public virtual string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public virtual string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public virtual int Status { get; set; }
        #endregion //Property
    }
}
