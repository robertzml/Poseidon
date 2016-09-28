using System;
using System.Collections.Generic;
using System.Linq;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 自定义模型属性类
    /// </summary>
    public class PoseidonProperty
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public PoseidonPropertyType Type { get; set; }

        /// <summary>
        /// 属性说明
        /// </summary>
        public string Remark { get; set; }
    }
}
