using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 用户对象数据访问接口
    /// </summary>
    internal interface IUserRepository : IBaseDAL<User>
    {
    }
}
