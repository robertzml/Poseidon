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
        /// 查找角色包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        IEnumerable<User> FindUsers(string id);

        /// <summary>
        /// 设置包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        void SetUsers(string id, List<string> uids);
    }
}
