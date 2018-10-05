using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 设施对象访问接口
    /// </summary>
    internal interface IFacilityRepository : IBaseDAL<Facility>
    {
        /// <summary>
        /// 根据模型类型查找设施
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        IEnumerable<Facility> FindByModelType(string modelType);

        /// <summary>
        /// 根据ID查找设施
        /// </summary>
        /// <param name="facilityIds">设施ID列表</param>
        /// <returns></returns>
        IEnumerable<Facility> FindWithIds(List<string> facilityIds);
    }
}
