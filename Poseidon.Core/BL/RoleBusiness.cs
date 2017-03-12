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
    public class RoleBusiness : AbstractBusiness<Role>
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
    }
}
