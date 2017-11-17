using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 数据集业务类
    /// </summary>
    public class DatasetBusiness : AbstractBusiness<Dataset>, IBaseBL<Dataset>
    {
        #region Constructor
        /// <summary>
        /// 数据集业务类
        /// </summary>
        public DatasetBusiness()
        {
            this.baseDal = RepositoryFactory<IDatasetRepository>.Instance;
        }
        #endregion //Constructor
    }
}
