using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.System
{
    /// <summary>
    /// 数据操作
    /// </summary>
    [Flags]
    public enum DataAction
    {
        /// <summary>
        /// 新增
        /// </summary>
        [Display(Name = "新增")]
        Create = 0x0008,

        /// <summary>
        /// 读取
        /// </summary>
        [Display(Name = "读取")]
        Read = 0x0004,

        /// <summary>
        /// 编辑
        /// </summary>
        [Display(Name = "编辑")]
        Update = 0x0002,

        /// <summary>
        /// 删除
        /// </summary>
        [Display(Name = "删除")]
        Delete = 0x0001
    }
}
