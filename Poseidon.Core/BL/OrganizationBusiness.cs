using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 组织对象业务类
    /// </summary>
    public class OrganizationBusiness : AbsctractBusiness<Organization>
    {
        #region Field

        #endregion //Field

        #region Constructor
        /// <summary>
        /// 组织对象业务类
        /// </summary>
        public OrganizationBusiness()
        {
            this.baseDal = RepositoryFactory<IOrganizationRepository>.Instance;
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
