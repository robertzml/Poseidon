using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 设施业务访问服务接口
    /// </summary>
    public interface IFacilityService : IBaseService<Facility>
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
