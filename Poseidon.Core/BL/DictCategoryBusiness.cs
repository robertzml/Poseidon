using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 字典分组业务类
    /// </summary>
    public class DictCategoryBusiness : AbstractBusiness<DictCategory>, IBaseBL<DictCategory>
    {
        #region Constructor
        /// <summary>
        /// 字典分组业务类
        /// </summary>
        public DictCategoryBusiness()
        {
            this.baseDal = RepositoryFactory<IDictCategoryRepository>.Instance;
        }
        #endregion //Constructor
    }
}
