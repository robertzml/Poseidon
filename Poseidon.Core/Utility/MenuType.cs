using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.Utility
{
    /// <summary>
    /// 菜单类型
    /// </summary>
    public enum MenuType
    {
        /// <summary>
        /// 页面
        /// </summary>
        [Display(Name = "页面")]
        Page = 1,

        /// <summary>
        /// 分组
        /// </summary>
        [Display(Name = "分组")]
        Group = 2,

        /// <summary>
        /// 按钮
        /// </summary>
        [Display(Name = "按钮")]
        Button = 3
    }
}
