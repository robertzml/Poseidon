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
    /// 组织分组对象访问接口
    /// </summary>
    internal interface IGroupRepository : IBaseDAL<Group>
    {
        /// <summary>
        /// 绑定模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        void AddModelTypes(string id, List<string> codes);
    }
}
