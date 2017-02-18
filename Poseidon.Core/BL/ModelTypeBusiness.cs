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
    /// 模型类型业务类
    /// </summary>
    public class ModelTypeBusiness : AbsctractBusiness<ModelType>
    {
        #region Constructor
        public ModelTypeBusiness()
        {
            this.baseDal = RepositoryFactory<IModelTypeRepository>.Instance;
        }
        #endregion //Constructor
    }
}
