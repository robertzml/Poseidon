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
    /// 模型类型业务访问服务接口
    /// </summary>
    public interface IModelTypeService : IBaseService<ModelType>
    {
        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        ModelType FindByCode(string code);

        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        IEnumerable<ModelType> FindWithCodes(List<string> codes);

        /// <summary>
        /// 根据分类获取模型类型
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        IEnumerable<ModelType> FindByCategory(int category);

        /// <summary>
        /// 按模块获取模型类型
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <returns></returns>
        IEnumerable<ModelType> FindByModule(string module);
    }
}
