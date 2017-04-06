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
    /// 角色数据访问接口
    /// </summary>
    internal interface IRoleRepository : IBaseDAL<Role>
    {
        /// <summary>
        /// 关联用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        void SetUsers(string id, List<string> uids);
    }
}
