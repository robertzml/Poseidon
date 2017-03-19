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
    public class UserService : AbstractLocalService<User>, IUserService
    {
        #region Field
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
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
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
        #endregion //Method
    }
}
