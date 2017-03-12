using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness : AbstractBusiness<User>, IBaseBL<User>
    {
        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserBusiness()
        {
            this.baseDal = RepositoryFactory<IUserRepository>.Instance;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新登录时间
        /// </summary>
        /// <param name="_id">用户系统ID</param>
        /// <param name="last">上次登录时间</param>
        /// <param name="current">本次登录时间</param>
        private void UpdateLoginTime(User user, DateTime last, DateTime current)
        {
            var dal = this.baseDal as IUserRepository;

            user.LastLoginTime = last;
            user.CurrentLoginTime = current;

            dal.Update(user);

            return;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 按用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public User FindByUserName(string userName)
        {
            return this.baseDal.FindOneByField("userName", userName);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            var dal = this.baseDal as IUserRepository;

            long count = dal.Count("userName", userName);
            if (count == 0)
                return false;

            var user = dal.FindOneByField("userName", userName);

            if (password != user.Password)
                return false;

            UpdateLoginTime(user, user.CurrentLoginTime, DateTime.Now);

            return true;
        }
        #endregion //Method
    }
}
