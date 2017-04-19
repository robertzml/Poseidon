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
    }
}
