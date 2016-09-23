using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

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
        /// <summary>
        /// 根据ID查找能源模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public EnergyModel FindById(string id)
        {
            var data = this.dal.FindById(id);
            return data;
        }

        /// <summary>
        /// 获取所有能源模型
        /// </summary>
        /// <returns></returns>
        public List<EnergyModel> FindAll()
        {
            var data = this.dal.FindAll();
            return data.ToList();
        }

        public ErrorCode Create(EnergyModel model, List<ModelProperty> properties)
        {
            var result = this.dal.Create(model, properties);
            return result;
        }
        #endregion //Method
    }
}
