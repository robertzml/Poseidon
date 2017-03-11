using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    /// <summary>
    /// 连接字符串来源
    /// </summary>
    public enum ConnectionSource
    {
        /// <summary>
        /// 默认
        /// </summary>
        /// <remarks>
        /// 由配置文件DbConnection设置
        /// </remarks>
        [Display(Name = "默认")]
        Default = 0,

        /// <summary>
        /// 代码硬编码
        /// </summary>
        /// <remarks>
        /// GetConnectionString方法获取
        /// </remarks>
        Code = 1,

        /// <summary>
        /// 配置文件
        /// </summary>
        /// <remarks>
        /// 配置文件指定连接
        /// </remarks>
        [Display(Name = "配置文件")]
        Config = 2,

        /// <summary>
        /// 缓存
        /// </summary>
        [Display(Name = "缓存")]
        Cache = 3
    }
}
