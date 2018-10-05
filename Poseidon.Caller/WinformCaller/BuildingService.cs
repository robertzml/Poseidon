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
    /// 建筑业务访问服务类
    /// </summary>
    internal class BuildingService : AbstractLocalService<Building>, IBuildingService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private BuildingBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 建筑业务访问服务类
        /// </summary>
        public BuildingService() : base(BusinessFactory<BuildingBusiness>.Instance)
        {
            this.bl = this.baseBL as BuildingBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据模型类型查找建筑
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Building> FindByModelType(string modelType)
        {
            return this.bl.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找建筑
        /// </summary>
        /// <param name="buildingIds">建筑ID列表</param>
        /// <returns></returns>
        public IEnumerable<Building> FindWithIds(List<string> buildingIds)
        {
            return this.bl.FindWithIds(buildingIds);
        }
        #endregion //Method
    }
}
