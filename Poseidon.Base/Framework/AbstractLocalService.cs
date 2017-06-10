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
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractLocalService<T, Tkey> : IBaseService<T, Tkey> where T : IBaseEntity<Tkey>
    {
        #region Field
        /// <summary>
        /// 业务接口
        /// </summary>
        protected IBaseBL<T, Tkey> baseBL;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 抽象本地服务调用类
        /// </summary>
        /// <param name="bl">业务对象</param>
        public AbstractLocalService(IBaseBL<T, Tkey> bl)
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
        public virtual T FindById(Tkey id)
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

        /// <summary>
        /// 查找所有正常状态对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAllNormal()
        {
            return this.baseBL.FindAllNormal();
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            return this.baseBL.Count();
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
        public virtual T Create(T entity)
        {
            return this.baseBL.Create(entity);
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="entity">指定的对象</param>
        /// <param name="generateKey">是否自动生成主键</param>
        /// <returns></returns>
        public virtual T Create(T entity, bool generateKey)
        {
            return this.baseBL.Create(entity, generateKey);
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

    /// <summary>
    /// 抽象本地服务调用类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractLocalService<T> : AbstractLocalService<T, string> where T : BaseEntity
    {
        #region Constructor
        /// <summary>
        /// 抽象本地服务调用类
        /// </summary>
        /// <param name="bl">业务对象</param>
        public AbstractLocalService(IBaseBL<T> bl) : base(bl)
        {
        }
        #endregion /Constructor
    }
}
