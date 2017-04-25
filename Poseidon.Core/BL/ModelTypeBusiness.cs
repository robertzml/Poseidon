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
    public class ModelTypeBusiness : AbstractBusiness<ModelType>, IBaseBL<ModelType>
    {
        #region Constructor
        public ModelTypeBusiness()
        {
            this.baseDal = RepositoryFactory<IModelTypeRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public ModelType FindByCode(string code)
        {
            var dal = this.baseDal as IModelTypeRepository;
            return dal.FindByCode(code);
        }

        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindWithCodes(List<string> codes)
        {
            var dal = this.baseDal as IModelTypeRepository;
            return dal.FindWithCodes(codes);
        }

        /// <summary>
        /// 根据类型获取模型类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindByType(int type)
        {
            return this.baseDal.FindListByField("type", type);
        }
        #endregion //Method
    }
}
