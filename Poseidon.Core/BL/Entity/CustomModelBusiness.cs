using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 自定义模型业务类
    /// </summary>
    public class CustomModelBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private ICustomModelRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 自定义模型业务类
        /// </summary>
        public CustomModelBusiness()
        {
            this.dal = RepositoryFactory<ICustomModelRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据类型获取自定义模型
        /// </summary>
        /// <param name="type">模型类型</param>
        /// <returns></returns>
        public List<CustomModel> FindByType(CustomModelType type)
        {
            var data = this.dal.FindByType(type);
            return data.ToList();
        }
        #endregion //Method
    }
}
