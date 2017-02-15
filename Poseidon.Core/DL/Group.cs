using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 分组类
    /// </summary>
    public class Group : BaseEntity
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 代号
        /// </summary>
        public string Code { get; set; }
    }
}
