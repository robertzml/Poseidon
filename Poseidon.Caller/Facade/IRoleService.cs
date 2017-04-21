using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 角色业务访问服务接口
    /// </summary>
    public interface IRoleService : IBaseService<Role>
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
        /// 根据代码获取角色
        /// </summary>
        /// <param name="code">角色代码</param>
        /// <returns></returns>
        Role FindByCode(string code);

        /// <summary>
        /// 查找角色包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        IEnumerable<User> GetUsers(string id);

        /// <summary>
        /// 设置包含用户
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
