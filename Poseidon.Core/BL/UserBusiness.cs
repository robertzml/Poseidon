using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Base.Utility;
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
        /// 按ID查找用户
        /// </summary>
        /// <param name="ids">用户ID列表</param>
        /// <returns></returns>
        public IEnumerable<User> FindWithIds(List<string> ids)
        {
            var dal = this.baseDal as IUserRepository;
            return dal.FindWithIds(ids);
        }

        /// <summary>
        /// 检查用户是否Root
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        public bool IsRoot(string id)
        {
            RoleBusiness roleBusiness = new RoleBusiness();
            var role = roleBusiness.FindByCode(PoseidonConstant.RootRole);

            return role.Users.Contains(id);
        }

        /// <summary>
        /// 获取用户所有权限列表
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>权限代码列表</returns>
        public IEnumerable<string> GetPrivileges(string id)
        {
            List<string> codes = new List<string>();

            var user = this.baseDal.FindById(id);
            codes.AddRange(user.Privileges);

            RoleBusiness roleBusiness = new RoleBusiness();
            var roles = roleBusiness.FindUserRoles(id);
            foreach (var item in roles)
            {
                codes.AddRange(item.Privileges);
            }

            codes = codes.Distinct().ToList();

            return codes;
        }

        /// <summary>
        /// 检查用户是否含有指定权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="code">权限代码</param>
        /// <returns></returns>
        public bool HasPrivilege(string id, string code)
        {
            var codes = GetPrivileges(id);
            if (codes.Contains(code))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public (bool success, string errorMessage) Login(string userName, string password)
        {
            var dal = this.baseDal as IUserRepository;

            var user = dal.FindOneByField("userName", userName);
            if (user == null)
                return (false, "用户为空");

            if (user.Status == (int)EntityStatus.Disabled)
                return (false, "用户已禁用");

            if (password != user.Password)
                return (false, "用户名或密码错误");

            UpdateLoginTime(user, user.CurrentLoginTime, DateTime.Now);

            return (true, "");
        }

        /// <summary>
        /// 检查用户密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        public bool CheckPassword(string userName, string password)
        {
            var dal = this.baseDal as IUserRepository;
            var user = dal.FindOneByField("userName", userName);
            if (user == null)
                return false;

            if (password != user.Password)
                return false;
            else
                return true;
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
            var dal = this.baseDal as IUserRepository;
            var user = dal.FindOneByField("userName", userName);
            if (user == null)
                return false;

            if (oldPassword != user.Password)
                return false;

            user.Password = newPassword;
            return dal.Update(user).success;
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="codes">权限代码列表</param>
        public void SetPrivileges(string id, List<string> codes)
        {
            var dal = this.baseDal as IUserRepository;
            dal.SetPrivileges(id, codes);
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Enable(string id)
        {
            var user = baseDal.FindById(id);
            user.Status = (int)EntityStatus.Normal;

            baseDal.Update(user);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void Disable(string id)
        {
            if (IsRoot(id))
            {
                throw new PoseidonException("超级用户无法禁用");
            }

            var user = baseDal.FindById(id);
            user.Status = (int)EntityStatus.Disabled;

            baseDal.Update(user);
        }
        #endregion //Method
    }
}
