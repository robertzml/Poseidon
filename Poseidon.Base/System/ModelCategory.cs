using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.System
{
    /// <summary>
    /// 模型分类
    /// </summary>
    public enum ModelCategory
    {
        /// <summary>
        /// 组织模型
        /// </summary>
        [Display(Name = "组织模型")]
        Organization = 1,

        /// <summary>
        /// 建筑模型
        /// </summary>
        [Display(Name = "建筑模型")]
        Building = 2,

        /// <summary>
        /// 文件模型
        /// </summary>
        [Display(Name = "文件模型")]
        File = 3,

        /// <summary>
        /// 设施模型
        /// </summary>
        [Display(Name = "设施模型")]
        Facility = 4
    }
}
