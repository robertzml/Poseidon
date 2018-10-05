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
    /// 设施业务访问服务类
    /// </summary>
    internal class FacilityService : AbstractLocalService<Facility>, IFacilityService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private FacilityBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 设施业务访问服务类
        /// </summary>
        public FacilityService() : base(BusinessFactory<FacilityBusiness>.Instance)
        {
            this.bl = this.baseBL as FacilityBusiness;
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
            return this.bl.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找设施
        /// </summary>
        /// <param name="facilityIds">设施ID列表</param>
        /// <returns></returns>
        public IEnumerable<Facility> FindWithIds(List<string> facilityIds)
        {
            return this.bl.FindWithIds(facilityIds);
        }
        #endregion //Method
    }
}
