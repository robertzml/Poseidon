using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 对象模型类
    /// </summary>
    /// <remarks>
    /// 自定义的各类对象模型类
    /// </remarks>
    public class ObjectModel : PoseidonModel
    {
        /// <summary>
        /// 是否抽象类
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
