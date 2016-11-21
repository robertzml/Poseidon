using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 实体对象类
    /// </summary>
    /// <remarks>
    /// 自定义的各种实体模型的具体对象类
    /// </remarks>
    public class EntityObject : PoseidonObject
    {
        /// <summary>
        /// 存储集合名称
        /// </summary>
        public string CollectionName { get; set; }
    }
}
