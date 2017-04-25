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
    /// 建筑对象业务类
    /// </summary>
    public class BuildingBusiness : AbstractBusiness<Building>, IBaseBL<Building>
    {
        #region Constructor
        /// <summary>
        /// 建筑对象业务类
        /// </summary>
        public BuildingBusiness()
        {
            this.baseDal = RepositoryFactory<IBuildingRepository>.Instance;
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
            var dal = this.baseDal as IBuildingRepository;
            return dal.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找建筑
        /// </summary>
        /// <param name="buildingIds">建筑ID列表</param>
        /// <returns></returns>
        public IEnumerable<Building> FindWithIds(List<string> buildingIds)
        {
            var dal = this.baseDal as IBuildingRepository;
            return dal.FindWithIds(buildingIds);
        }
        #endregion //Method
    }
}
