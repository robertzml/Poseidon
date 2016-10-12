using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 对象模型业务类
    /// </summary>
    public class ObjectModelBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IObjectModelRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 自定义模型业务类
        /// </summary>
        public ObjectModelBusiness()
        {
            this.dal = RepositoryFactory<IObjectModelRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ObjectModel FindById(string id)
        {
            var data = this.dal.FindById(id);
            return data;
        }

        /// <summary>
        /// 根据类型标识查找
        /// </summary>
        /// <param name="key">类型标识</param>
        /// <returns></returns>
        public ObjectModel FindByKey(string key)
        {
            var data = this.dal.FindByField<string>("key", key);
            return data;
        }

        /// <summary>
        /// 查找所有对象模型
        /// </summary>
        /// <returns></returns>
        public List<ObjectModel> FindAll()
        {
            var data = this.dal.FindAll();
            return data.ToList();
        }

        /// <summary>
        /// 添加对象模型
        /// </summary>
        /// <param name="entity">模型实体</param>
        /// <returns></returns>
        public ErrorCode Create(ObjectModel entity)
        {
            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
