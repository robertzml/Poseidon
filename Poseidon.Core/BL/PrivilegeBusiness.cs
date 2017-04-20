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
    /// 权限业务类
    /// </summary>
    public class PrivilegeBusiness : AbstractBusiness<Privilege>, IBaseBL<Privilege>
    {
        #region Constructor
        /// <summary>
        /// 权限业务类
        /// </summary>
        public PrivilegeBusiness()
        {
            this.baseDal = RepositoryFactory<IPrivilegeRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码查找权限
        /// </summary>
        /// <param name="code">权限代码</param>
        /// <returns></returns>
        public Privilege FindByCode(string code)
        {
            var entity = this.baseDal.FindOneByField("code", code);
            return entity;
        }

        /// <summary>
        /// 根据代码获取权限
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        public IEnumerable<Privilege> FindWithCodes(List<string> codes)
        {
            var dal = this.baseDal as IPrivilegeRepository;
            return dal.FindWithCodes(codes);
        }
        #endregion //Method
    }
}
