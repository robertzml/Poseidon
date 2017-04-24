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
    /// 权限业务访问服务接口
    /// </summary>
    public interface IPrivilegeService : IBaseService<Privilege>
    {
        /// <summary>
        /// 根据代码查找权限
        /// </summary>
        /// <param name="code">权限代码</param>
        /// <returns></returns>
        Privilege FindByCode(string code);

        /// <summary>
        /// 根据代码获取权限
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        IEnumerable<Privilege> FindWithCodes(List<string> codes);
    }
}
