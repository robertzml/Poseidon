using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 权限数据访问接口
    /// </summary>
    internal interface IPrivilegeRepository : IBaseDAL<Privilege>
    {
    }
}
