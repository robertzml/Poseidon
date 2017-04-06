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
    /// 组织业务访问服务类
    /// </summary>
    internal class OrganizationService : AbstractLocalService<Organization>, IOrganizationService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private OrganizationBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 组织业务访问服务类
        /// </summary>
        public OrganizationService() : base(BusinessFactory<OrganizationBusiness>.Instance)
        {
            this.bl = this.baseBL as OrganizationBusiness;
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
            return this.bl.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找组织
        /// </summary>
        /// <param name="organizationIds">组织ID列表</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindWithIds(List<string> organizationIds)
        {
            return this.bl.FindWithIds(organizationIds);
        }

        /// <summary>
        /// 查找分组项对应组织
        /// </summary>
        /// <param name="items">分组项</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindByGroupItem(List<GroupItem> items)
        {
            return this.bl.FindByGroupItem(items);
        }
        #endregion //Method
    }
}
