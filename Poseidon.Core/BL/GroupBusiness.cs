using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 分组对象业务类
    /// </summary>
    public class GroupBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IGroupRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分组对象业务类
        /// </summary>
        public GroupBusiness()
        {
            this.dal = RepositoryFactory<IGroupRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加分组对象
        /// </summary>
        /// <param name="entity">分组对象</param>
        /// <returns></returns>
        public ErrorCode Create(Group entity)
        {
            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
