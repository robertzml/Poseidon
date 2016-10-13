using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 实体模型类
    /// </summary>
    /// <remarks>
    /// 自定义的各种实体模型类
    /// </remarks>
    public class EntityModel : PoseidonModel
    {
        /// <summary>
        /// 是否抽象类
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// 存储表名，默认为 entityObject 表
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
