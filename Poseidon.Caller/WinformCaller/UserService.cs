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
        #endregion //Method
    }
}
