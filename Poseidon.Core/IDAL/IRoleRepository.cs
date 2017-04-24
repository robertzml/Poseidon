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
        /// 获取所有角色
        /// </summary>
        /// <param name="includeRoot">是否包含Root</param>
        /// <returns></returns>
        IEnumerable<Role> FindAll(bool includeRoot);

        /// <summary>
        /// 查找用户所有角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        IEnumerable<Role> FindUserRoles(string userId);

        /// <summary>
        /// 关联用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        void SetUsers(string id, List<string> uids);

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="codes">权限代码列表</param>
        void SetPrivileges(string id, List<string> codes);
    }
}
