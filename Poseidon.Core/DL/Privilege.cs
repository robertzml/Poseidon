using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 权限类
    /// </summary>
    public class Privilege : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 数据行为
        /// </summary>
        [Display(Name = "数据行为")]
        public int Action { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        public int Sort { get; set; }
        #endregion //Property
    }
}
