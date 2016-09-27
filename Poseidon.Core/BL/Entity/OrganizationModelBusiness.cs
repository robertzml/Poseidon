using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 组织模型业务类
    /// </summary>
    public class OrganizationModelBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IOrganizationModelRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 组织模型业务类
        /// </summary>
        public OrganizationModelBusiness()
        {
            this.dal = RepositoryFactory<IOrganizationModelRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据ID查找组织模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public OrganizationModel FindById(string id)
        {
            var data = this.dal.FindById(id);
            return data;
        }

        /// <summary>
        /// 获取所有组织模型
        /// </summary>
        /// <returns></returns>
        public List<OrganizationModel> FindAll()
        {
            var data = this.dal.FindAll();
            return data.ToList();
        }

        #endregion //Method
    }
}
