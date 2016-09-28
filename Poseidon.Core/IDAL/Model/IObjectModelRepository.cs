using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 对象模型数据访问接口
    /// </summary>
    internal interface IObjectModelRepository : IBaseDAL<ObjectModel>
    {
        /// <summary>
        /// 根据类型获取对象模型
        /// </summary>
        /// <param name="type">模型类型</param>
        /// <returns></returns>
        IEnumerable<ObjectModel> FindByType(ModelType type);
    }
}
