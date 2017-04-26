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
    /// 组织业务访问服务接口
    /// </summary>
    public interface IOrganizationService : IBaseService<Organization>
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
