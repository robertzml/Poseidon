using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Model
{
    /// <summary>
    /// 自定义模型类型
    /// </summary>
    public enum CustomModelType
    {
        /// <summary>
        /// 基础对象
        /// </summary>
        [Display(Name = "基础对象")]
        Base = 0,

        /// <summary>
        /// 能源模型
        /// </summary>
        [Display(Name = "能源模型")]
        Energy = 1,

        /// <summary>
        /// 组织模型
        /// </summary>
        [Display(Name = "组织模型")]
        Organization = 2
    }
}
