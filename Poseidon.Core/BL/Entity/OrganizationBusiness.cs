using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 组织对象业务类
    /// </summary>
    public class OrganizationBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IOrganizationRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 组织对象业务类
        /// </summary>
        public OrganizationBusiness()
        {
            this.dal = RepositoryFactory<IOrganizationRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        public ErrorCode Create(Organization entity)
        {
            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
