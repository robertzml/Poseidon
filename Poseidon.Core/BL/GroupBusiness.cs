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
    public class GroupBusiness : AbsctractBusiness<Group>
    {
        #region Field

        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分组对象业务类
        /// </summary>
        public GroupBusiness()
        {
            this.baseDal = RepositoryFactory<IGroupRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        public void AddModelTypes(string id, List<string> codes)
        {
            var dal = this.baseDal as IGroupRepository;
            dal.AddModelTypes(id, codes);
            return;
        }
        #endregion //Method
    }
}
