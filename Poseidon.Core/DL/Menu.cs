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
    /// 菜单类
    /// </summary>
    public class Menu : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 程序集名称
        /// </summary>
        [Display(Name = "程序集名称")]
        public string AssemblyName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        [Display(Name = "类型名称")]
        public string TypeName { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        public string Glyph { get; set; }

        /// <summary>
        /// 大图标
        /// </summary>
        [Display(Name = "大图标")]
        public string LargeGlyph { get; set; }

        /// <summary>
        /// 权限代码
        /// </summary>
        [Display(Name = "权限代码")]
        public string PrivilegeCode { get; set; }

        /// <summary>
        /// 菜单类型
        /// </summary>
        [Display(Name = "菜单类型")]
        public int Type { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [Display(Name = "排序码")]
        public int Sort { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }
        #endregion //Property
    }
}
