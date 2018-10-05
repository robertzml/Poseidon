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
    /// 文件业务访问服务接口
    /// </summary>
    public interface IFileService : IBaseService<File>
    {
        /// <summary>
        /// 根据模型类型查找文件
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        IEnumerable<File> FindByModelType(string modelType);

        /// <summary>
        /// 根据ID查找文件
        /// </summary>
        /// <param name="fileIds">文件ID列表</param>
        /// <returns></returns>
        IEnumerable<File> FindWithIds(List<string> fileIds);
    }
}
