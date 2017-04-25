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
    /// 建筑对象访问接口
    /// </summary>
    internal interface IBuildingRepository : IBaseDAL<Building>
    {
        /// <summary>
        /// 根据模型类型查找建筑
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        IEnumerable<Building> FindByModelType(string modelType);

        /// <summary>
        /// 根据ID查找建筑
        /// </summary>
        /// <param name="buildingIds">建筑ID列表</param>
        /// <returns></returns>
        IEnumerable<Building> FindWithIds(List<string> buildingIds);
    }
}
