using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 自定义模型类
    /// </summary>
    /// <remarks>
    /// 表示一个类型，该类型的属性由属性列表描述。
    /// 类型是动态的，运行时确定类型属性。
    /// </remarks>
    public class PoseidonModel : BaseEntity
    {
        #region Property
        /// <summary>
        /// 标识
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 继承基类
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// 属性列表
        /// </summary>
        public List<PoseidonProperty> Properties { get; set; }
        #endregion //Property
    }
}
