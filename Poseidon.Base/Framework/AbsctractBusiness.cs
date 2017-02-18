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
    public abstract class AbsctractBusiness<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        protected IBaseDAL<T> baseDal;
        #endregion //Field

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(string id)
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
        #endregion //Method
    }
}
