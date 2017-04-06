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
    /// 字典业务访问服务接口
    /// </summary>
    public interface IDictService : IBaseService<Dict>
    {
        /// <summary>
        /// 按分类查找
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns></returns>
        IEnumerable<Dict> FindByCategory(string categoryId);

        /// <summary>
        /// 查找字典值
        /// </summary>
        /// <param name="code">字典代码</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        string FindValue(string code, int key);

        /// <summary>
        /// 查找字典项
        /// </summary>
        /// <param name="code">字典代码</param>
        /// <returns></returns>
        List<DictItem> FindItems(string code);
    }
}
