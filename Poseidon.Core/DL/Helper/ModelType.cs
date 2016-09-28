using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    /// <summary>
    /// 自定义模型类型
    /// </summary>
    public enum ModelType
    {
        /// <summary>
        /// 基础对象
        /// </summary>
        [Display(Name = "基础对象")]
        Base = 0,

        /// <summary>
        /// 对象模型
        /// </summary>
        [Display(Name = "对象模型")]
        Object = 1,

        /// <summary>
        /// 业务模型
        /// </summary>
        [Display(Name = "业务模型")]
        Business = 2
    }
}
