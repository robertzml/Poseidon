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
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            return this.baseDal.FindOneByField(field, value);
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
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            return this.baseDal.FindListByField(field, value);
        }

        /// <summary>
        /// 按ID列表查找记录
        /// </summary>
        /// <param name="values">ID列表</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListInIds(List<Tkey> values)
        {
            return this.baseDal.FindListInIds(values);
        }

        /// <summary>
        /// 查找所有正常状态对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAllNormal()
        {
            return this.baseDal.FindByStatus(EntityStatus.Normal);
        }

        /// <summary>
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
        {
            return this.baseDal.FindByStatus(status);
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            return this.baseDal.Count();
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
            return this.baseDal.Count(field, value);
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public virtual T Create(T entity)
        {
            return this.baseDal.Create(entity);
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="entity">指定的对象</param>
        /// <param name="generateKey">是否自动生成主键</param>
        /// <returns></returns>
        public virtual T Create(T entity, bool generateKey)
        {
            return this.baseDal.Create(entity, generateKey);
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

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual bool Delete(Tkey id)
        {
            return this.baseDal.Delete(id);
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public virtual void MarkDelete(T entity)
        {
            this.baseDal.MarkDelete(entity);
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="id">ID</param>
        public virtual void MarkDelete(Tkey id)
        {
            this.baseDal.MarkDelete(id);
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
