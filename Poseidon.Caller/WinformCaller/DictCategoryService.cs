using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 字典分类业务访问服务类
    /// </summary>
    internal class DictCategoryService : AbstractLocalService<DictCategory>, IDictCategoryService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private DictCategoryBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 字典分类业务访问服务类
        /// </summary>
        public DictCategoryService() : base(BusinessFactory<DictCategoryBusiness>.Instance)
        {
            this.bl = this.baseBL as DictCategoryBusiness;
        }
        #endregion //Constructor
    }
}
