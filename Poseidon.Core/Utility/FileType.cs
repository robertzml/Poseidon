using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.Utility
{
    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 普通文件
        /// </summary>
        [Display(Name = "普通文件")]
        Normal = 1,

        /// <summary>
        /// 目录文件
        /// </summary>
        [Display(Name = "目录文件")]
        Directory = 2,

        /// <summary>
        /// 链接文件
        /// </summary>
        [Display(Name = "链接文件")]
        Link = 3,

        /// <summary>
        /// 特殊文件
        /// </summary>
        [Display(Name = "特殊文件")]
        Special = 4
    }
}
