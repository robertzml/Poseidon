using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 抽象本地服务调用类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractLocalService<T> : IBaseService<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// 业务接口
        /// </summary>
        protected IBaseBL<T> baseBL;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 抽象本地服务调用类
        /// </summary>
        /// <param name="bl">业务对象</param>
        public AbstractLocalService(IBaseBL<T> bl)
        {
            this.baseBL = bl;
        }
        #endregion /Constructor

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(string id)
        {
            return this.baseBL.FindById(id);
        }

        public virtual T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            return this.baseBL.FindAll();
        }

        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual void Create(T entity)
        {
            this.baseBL.Create(entity);
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual bool Update(T entity)
        {
            return this.baseBL.Update(entity);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            return this.baseBL.Delete(entity);
        }
        #endregion //Method
    }
}
