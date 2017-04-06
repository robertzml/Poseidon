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
        /// 创建标注
        /// </summary>
        [Display(Name = "创建标注")]
        public virtual UpdateStamp CreateBy { get; set; }

        /// <summary>
        /// 修改标注
        /// </summary>
        [Display(Name = "修改标注")]
        public virtual UpdateStamp UpdateBy { get; set; }

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

    /// <summary>
    /// 标注类
    /// </summary>
    public class UpdateStamp
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public string UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Display(Name = "时间")]
        public DateTime Time { get; set; }
    }
}
