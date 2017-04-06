using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 组织对象访问接口
    /// </summary>
    internal interface IOrganizationRepository : IBaseDAL<Organization>
    {
        /// <summary>
        /// 根据模型类型查找组织
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        IEnumerable<Organization> FindByModelType(string modelType);

        /// <summary>
        /// 根据ID查找组织
        /// </summary>
        /// <param name="organizationIds">组织ID列表</param>
        /// <returns></returns>
        IEnumerable<Organization> FindWithIds(List<string> organizationIds);
    }
}
