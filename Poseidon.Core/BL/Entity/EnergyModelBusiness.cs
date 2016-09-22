using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base;
    using Poseidon.Base.Entity;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Model;

    /// <summary>
    /// 能耗模型业务类
    /// </summary>
    public class EnergyModelBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IEnergyModelRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 能耗模型业务类
        /// </summary>
        public EnergyModelBusiness()
        {
            this.dal = RepositoryFactory<IEnergyModelRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        public ErrorCode Create(EnergyModel model, List<ModelProperty> properties)
        {
            var result = this.dal.Create(model, properties);
            return result;
        }

        public List<EnergyModel> FindAll()
        {
            var data = this.dal.FindAllWithMain();
            return data;
        }
        #endregion //Method
    }
}
