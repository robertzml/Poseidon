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
    /// 角色业务类
    /// </summary>
    public class RoleBusiness : AbstractBusiness<Role>, IBaseBL<Role>
    {
        #region Constructor
        /// <summary>
        /// 角色业务类
        /// </summary>
        public RoleBusiness()
        {
            this.baseDal = RepositoryFactory<IRoleRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 查找角色包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <returns></returns>
        public IEnumerable<User> FindUsers(string id)
        {
            var role = this.baseDal.FindById(id);

            UserBusiness ub = new UserBusiness();
            var data = ub.FindWithIds(role.Users);
            return data;
        }

        /// <summary>
        /// 设置包含用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        public void SetUsers(string id, List<string> uids)
        {
            var dal = this.baseDal as IRoleRepository;
            dal.SetUsers(id, uids);
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="codes">权限代码列表</param>
        public void SetPrivileges(string id, List<string> codes)
        {
            var dal = this.baseDal as IRoleRepository;
            dal.SetPrivileges(id, codes);
        }
        #endregion //Method
    }
}
