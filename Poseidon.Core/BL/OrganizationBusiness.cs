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
        /// <summary>
        /// 根据模型类型查找组织
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindByModelType(string modelType)
        {
            var dal = this.baseDal as IOrganizationRepository;
            return dal.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找组织
        /// </summary>
        /// <param name="organizationIds">组织ID列表</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindWithIds(List<string> organizationIds)
        {
            var dal = this.baseDal as IOrganizationRepository;
            return dal.FindWithIds(organizationIds);
        }
        #endregion //Method
    }
}
