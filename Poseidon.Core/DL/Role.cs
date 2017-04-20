using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 角色类
    /// </summary>
    public class Role : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        public int Sort { get; set; }

        /// <summary>
        /// 包含用户ID
        /// </summary>
        [Display(Name = "包含用户")]
        public List<string> Users { get; set; }

        /// <summary>
        /// 包含权限代码
        /// </summary>
        [Display(Name = "包含权限代码")]
        public List<string> Privileges { get; set; }
        #endregion //Property
    }
}
