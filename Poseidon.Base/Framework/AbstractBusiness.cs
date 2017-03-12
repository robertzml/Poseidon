using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;

    /// <summary>
    /// 抽象业务类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractBusiness<T, Tkey> : IBaseBL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        protected IBaseDAL<T, Tkey> baseDal;
        #endregion //Field

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(Tkey id)
        {
            return this.baseDal.FindById(id);
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            return this.baseDal.FindAll();
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public virtual void Create(T entity)
        {
            this.baseDal.Create(entity);
            return;
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        public virtual bool Update(T entity)
        {
            return this.baseDal.Update(entity);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            return this.baseDal.Delete(entity);
        }
        #endregion //Method
    }

    /// <summary>
    /// 抽象业务类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractBusiness<T> : AbstractBusiness<T, string> where T : BaseEntity
    {
    }
}
