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
    /// 实体模型业务类
    /// </summary>
    public class EntityModelBusiness
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IEntityModelRepository dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 自定义模型业务类
        /// </summary>
        public EntityModelBusiness()
        {
            this.dal = RepositoryFactory<IEntityModelRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public EntityModel FindById(string id)
        {
            var data = this.dal.FindById(id);
            return data;
        }

        /// <summary>
        /// 根据类型标识查找
        /// </summary>
        /// <param name="key">类型标识</param>
        /// <returns></returns>
        public EntityModel FindByKey(string key)
        {
            var data = this.dal.FindByField<string>("key", key);
            return data;
        }

        /// <summary>
        /// 查找所有对象模型
        /// </summary>
        /// <returns></returns>
        public List<EntityModel> FindAll()
        {
            var data = this.dal.FindAll();
            return data.ToList();
        }

        /// <summary>
        /// 添加对象模型
        /// </summary>
        /// <param name="entity">模型实体</param>
        /// <returns></returns>
        public ErrorCode Create(EntityModel entity)
        {
            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
