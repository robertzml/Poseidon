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
    public class OrganizationBusiness
    {
        #region Field
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
        /// <summary>
        /// 添加组织对象
        /// </summary>
        /// <param name="entity">组织对象实体</param>
        /// <returns></returns>
        public ErrorCode Create(Organization entity)
        {
            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
