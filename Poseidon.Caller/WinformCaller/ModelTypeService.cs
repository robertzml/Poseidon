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
    /// 模型类型业务访问服务类
    /// </summary>
    internal class ModelTypeService : AbstractLocalService<ModelType>, IModelTypeService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private ModelTypeBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 模型类型业务访问服务类
        /// </summary>
        public ModelTypeService() : base(BusinessFactory<ModelTypeBusiness>.Instance)
        {
            this.bl = this.baseBL as ModelTypeBusiness;
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
            return this.bl.FindByCode(code);
        }

        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindWithCodes(List<string> codes)
        {
            return this.bl.FindWithCodes(codes);
        }

        /// <summary>
        /// 根据分类获取模型类型
        /// </summary>
        /// <param name="category">分类</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindByCategory(int category)
        {
            return this.bl.FindByCategory(category);
        }

        /// <summary>
        /// 按模块获取模型类型
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindByModule(string module)
        {
            return this.bl.FindByModule(module);
        }
        #endregion //Method
    }
}
