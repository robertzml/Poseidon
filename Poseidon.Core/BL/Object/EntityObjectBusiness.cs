using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 实体对象业务类
    /// </summary>
    public class EntityObjectBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IEntityObjectRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 自定义对象业务类
        /// </summary>
        public EntityObjectBusiness()
        {
            this.dal = RepositoryFactory<IEntityObjectRepository>.Instance;
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
