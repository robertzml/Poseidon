using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 基础对象接口
    /// </summary>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IBaseEntity<Tkey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        Tkey Id { get; set; }
    }
}
