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
        /// 根据分类获取模型类型
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindByCategory(int category)
        {
            return this.baseDal.FindListByField("category", category);
        }

        /// <summary>
        /// 按模块查询模型类型
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindByModule(string module)
        {
            var dal = this.baseDal as IModelTypeRepository;
            return dal.FindListByField("module", module);
        }
        #endregion //Method
    }
}
