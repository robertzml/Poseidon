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
    /// 权限业务访问服务
    /// </summary>
    internal class PrivilegeService : AbstractLocalService<Privilege>, IPrivilegeService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private PrivilegeBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 权限业务访问服务
        /// </summary>
        public PrivilegeService() : base(BusinessFactory<PrivilegeBusiness>.Instance)
        {
            this.bl = this.baseBL as PrivilegeBusiness;
        }
        #endregion //Constructor
    }
}
