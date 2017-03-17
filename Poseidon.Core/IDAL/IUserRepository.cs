using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 用户对象数据访问接口
    /// </summary>
    internal interface IUserRepository : IBaseDAL<User>
    {
        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="ids">用户ID列表</param>
        /// <returns></returns>
        IEnumerable<User> FindWithIds(List<string> ids);
    }
}
