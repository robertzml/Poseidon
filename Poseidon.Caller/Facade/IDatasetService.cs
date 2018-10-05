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
    /// 数据集业务访问服务接口
    /// </summary>
    public interface IDatasetService : IBaseService<Dataset>
    {
        /// <summary>
        /// 根据代码查找数据集
        /// </summary>
        /// <param name="code">数据集代码</param>
        /// <returns></returns>
        Dataset FindByCode(string code);
    }
}
