using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;

    /// <summary>
    /// 自定义模型数据访问接口
    /// </summary>
    internal interface ICustomModelRepository : IBaseDAL<CustomModel>
    {
        /// <summary>
        /// 根据类型获取自定义模型
        /// </summary>
        /// <param name="type">模型类型</param>
        /// <returns></returns>
        IEnumerable<CustomModel> FindByType(CustomModelType type);
    }
}
