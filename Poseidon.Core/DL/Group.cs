using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 模型分组类
    /// </summary>
    public class Group : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        [Display(Name = "模块")]
        public string Module { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 关联模型类型Code
        /// </summary>
        [Display(Name = "关联模型类型")]
        public List<string> ModelTypes { get; set; }

        /// <summary>
        /// 包含对象
        /// </summary>
        [Display(Name = "包含对象")]
        public List<GroupItem> Items { get; set; }
        #endregion //Property
    }

    /// <summary>
    /// 分组项
    /// </summary>
    public class GroupItem : BaseEntity
    {
        #region Property
        /// <summary>
        /// 所在分组代码
        /// </summary>
        [Display(Name = "分组代码")]
        public string GroupCode { get; set; }

        /// <summary>
        /// 对象ID
        /// </summary>
        [Display(Name = "对象ID")]
        public string EntityId { get; set; }

        /// <summary>
        /// 模型类型代码
        /// </summary>
        [Display(Name = "模型类型")]
        public string ModelType { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        public int Sort { get; set; }
        #endregion //Property
    }
}
