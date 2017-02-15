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
        protected IBaseDAL<T> dal;
        #endregion //Field

        #region Method
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public virtual ErrorCode Create(T entity)
        {
            return this.dal.Create(entity);
        }
        #endregion //Method
    }
}
