using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 模型类型业务类
    /// </summary>
    public class ModelTypeBusiness : AbsctractBusiness<ModelType>
    {
        #region Constructor
        public ModelTypeBusiness()
        {
            this.dal = RepositoryFactory<IModelTypeRepository>.Instance;
        }
        #endregion //Constructor
    }
}
