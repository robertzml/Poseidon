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
    /// 用户数据访问服务类
    /// </summary>
    internal class UserService : AbstractLocalService<User>, IUserService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private UserBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户数据访问服务类
        /// </summary>
        public UserService() : base(BusinessFactory<UserBusiness>.Instance)
        {
            this.bl = this.baseBL as UserBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public User FindByUserName(string userName)
        {
            return this.bl.FindByUserName(userName);
        }

        /// <summary>
        /// 按ID查找用户
        /// </summary>
        /// <param name="ids">用户ID列表</param>
        /// <returns></returns>
        public IEnumerable<User> FindWithIds(List<string> ids)
        {
            return this.bl.FindWithIds(ids);
        }

        /// <summary>
        /// 检查用户是否Root
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool IsRoot(string id)
        {
            return this.bl.IsRoot(id);
        }

        /// <summary>
        /// 获取用户所有权限列表
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>权限代码列表</returns>
        public IEnumerable<string> GetPrivileges(string id)
        {
            return this.bl.GetPrivileges(id);
        }

        /// <summary>
        /// 检查用户是否含有指定权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="code">权限代码</param>
        /// <returns></returns>
        public bool HasPrivilege(string id, string code)
        {
            return this.bl.HasPrivilege(id, code);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Login(string userName, string password)
        {
            return this.bl.Login(userName, password);
        }

        /// <summary>
        /// 检查用户密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public bool CheckPassword(string userName, string password)
        {
            return this.bl.CheckPassword(userName, password);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            return this.bl.ChangePassword(userName, oldPassword, newPassword);
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="codes">权限代码列表</param>
        public void SetPrivileges(string id, List<string> codes)
        {
            this.bl.SetPrivileges(id, codes);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Enable(string id)
        {
            this.bl.Enable(id);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Disable(string id)
        {
            this.bl.Disable(id);
        }
        #endregion //Method
    }
}
