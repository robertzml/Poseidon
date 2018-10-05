using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;

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

        /// <summary>
        /// 异步根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual async Task<T> FindByIdAsync(Tkey id)
        {
            var task = Task.Run(() =>
            {
                return this.baseBL.FindById(id);
            });

            return await task;
        }

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
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

        /// <summary>
        /// 异步查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> FindAllAsync()
        {
            var task = Task.Run(() =>
            {
                return this.baseBL.FindAll();
            });

            return await task;
        }

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            return this.baseBL.FindListByField(field, value);
        }

        /// <summary>
        /// 按ID列表查找记录
        /// </summary>
        /// <param name="values">ID列表</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListInIds(List<Tkey> values)
        {
            return this.baseBL.FindListInIds(values);
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
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
        {
            return this.baseBL.FindByStatus(status);
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            return this.baseBL.Count();
        }

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual long Count<Tvalue>(string field, Tvalue value)
        {
            return this.baseBL.Count(field, value);
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
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual bool Delete(Tkey id)
        {
            return this.baseBL.Delete(id);
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

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual void MarkDelete(T entity)
        {
            this.baseBL.MarkDelete(entity);
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="id">ID</param>
        public virtual void MarkDelete(Tkey id)
        {
            this.baseBL.MarkDelete(id);
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
