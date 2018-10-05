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
    /// 设施对象业务类
    /// </summary>
    public class FacilityBusiness : AbstractBusiness<Facility>, IBaseBL<Facility>
    {
        #region Constructor
        /// <summary>
        /// 设施对象业务类
        /// </summary>
        public FacilityBusiness()
        {
            this.baseDal = RepositoryFactory<IFacilityRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据模型类型查找设施
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Facility> FindByModelType(string modelType)
        {
            var dal = this.baseDal as IFacilityRepository;
            return dal.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找设施
        /// </summary>
        /// <param name="facilityIds">设施ID列表</param>
        /// <returns></returns>
        public IEnumerable<Facility> FindWithIds(List<string> facilityIds)
        {
            var dal = this.baseDal as IFacilityRepository;
            return dal.FindWithIds(facilityIds);
        }
        #endregion //Method
    }
}
