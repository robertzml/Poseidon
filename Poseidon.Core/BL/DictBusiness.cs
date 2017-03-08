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
    /// 字典业务类
    /// </summary>
    public class DictBusiness : AbsctractBusiness<Dict>
    {
        #region Constructor
        /// <summary>
        /// 字典业务类
        /// </summary>
        public DictBusiness()
        {
            this.baseDal = RepositoryFactory<IDictRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按分类查找
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns></returns>
        public IEnumerable<Dict> FindByCategory(string categoryId)
        {
            return this.baseDal.FindListByField("categoryId", categoryId);
        }
        #endregion //Method
    }
}
