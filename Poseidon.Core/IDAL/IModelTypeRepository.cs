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
    /// 模型类型对象数据访问接口
    /// </summary>
    internal interface IModelTypeRepository : IBaseDAL<ModelType>
    {
        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        ModelType FindByCode(string code);
    }
}
