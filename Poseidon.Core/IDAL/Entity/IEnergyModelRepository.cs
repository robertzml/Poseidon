using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;

    /// <summary>
    /// 能源模型数据访问接口
    /// </summary>
    internal interface IEnergyModelRepository : IBaseDAL<EnergyModel>
    {
        /// <summary>
        /// 新增能源模型
        /// </summary>
        /// <param name="model">基础属性</param>
        /// <param name="properties">自定义属性</param>
        /// <returns></returns>
        ErrorCode Create(EnergyModel model, List<ModelProperty> properties);

        /// <summary>
        /// 获取所有能源模型基本属性
        /// </summary>
        /// <returns></returns>
        List<EnergyModel> FindAllWithMain();
    }
}
