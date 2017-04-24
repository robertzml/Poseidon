using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 角色业务访问服务类
    /// </summary>
    internal class RoleService : AbstractLocalService<Role>, IRoleService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private RoleBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分组业务访问服务类
        /// </summary>
        public RoleService() : base(BusinessFactory<RoleBusiness>.Instance)
        {
            this.bl = this.baseBL as RoleBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="includeRoot">是否包含Root</param>
        /// <returns></returns>
        public IEnumerable<Role> FindAll(bool includeRoot)
        {
            return this.bl.FindAll(includeRoot);
        }

        /// <summary>
        /// 查找用户所有角色
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public IEnumerable<Role> FindUserRoles(string userId)
        {
            return this.bl.FindUserRoles(userId);
        }

        /// <summary>
        /// 根据代码获取角色
        /// </summary>
        /// <param name="code">角色代码</param>
        /// <returns></returns>
        public Role FindByCode(string code)
        {
            return this.bl.FindByCode(code);
        }

        /// <summary>
        /// 查找角色包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(string id)
        {
            return this.bl.GetUsers(id);
        }

        /// <summary>
        /// 设置包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        public void SetUsers(string id, List<string> uids)
        {
            this.bl.SetUsers(id, uids);
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="codes">权限代码列表</param>
        public void SetPrivileges(string id, List<string> codes)
        {
            this.bl.SetPrivileges(id, codes);
        }
        #endregion //Method
    }
}
