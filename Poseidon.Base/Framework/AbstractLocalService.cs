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
        public T FindById(string id)
        {
            return this.baseBL.FindById(id);
        }

        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            throw new NotImplementedException();
        }


        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
