using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base
{
    using Poseidon.Base.Model;

    /// <summary>
    /// 数据库数据访问层接口
    /// </summary>
    /// <remarks>
    /// 针对表的数据CRUD操作
    /// </remarks>
    public interface IBaseDAL<T> where T : BaseEntity
    {
        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="obj">指定的对象</param>
        /// <returns>执行成功返回True</returns>
        bool Create(T obj);

        List<T> Read();
    }
}
