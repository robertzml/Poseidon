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
    /// 用户数据访问服务接口
    /// </summary>
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 按用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        User FindByUserName(string userName);
    }
}
