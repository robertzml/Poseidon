﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 模型分组对象访问接口
    /// </summary>
    internal interface IGroupRepository : IBaseDAL<Group>
    {
        /// <summary>
        /// 查找所有子分组
        /// </summary>
        /// <param name="id">父分组ID</param>
        /// <returns></returns>
        IEnumerable<Group> FindAllChildren(string id);

        /// <summary>
        /// 查找分组及子分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        IEnumerable<Group> FindWithChildrenByCode(string code);

        /// <summary>
        /// 绑定模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        void SetModelTypes(string id, List<string> codes);
    }
}
