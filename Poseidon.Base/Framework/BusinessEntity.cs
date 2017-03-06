using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 业务对象类
    /// </summary>
    public abstract class BusinessEntity : BaseEntity
    {
        #region Property
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Display(Name = "更新时间")]
        public virtual DateTime UpdateTime { get; set; }

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
