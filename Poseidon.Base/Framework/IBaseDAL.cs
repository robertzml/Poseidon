using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;

    /// <summary>
    /// 数据库数据访问层基础接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IBaseDAL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(Tkey id);

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        T FindOneByField<Tvalue>(string field, Tvalue value);

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        IEnumerable<T> FindByStatus(EntityStatus status);

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value);

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        long Count();

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        long Count<Tvalue>(string field, Tvalue value);

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="entity">指定的对象</param>
        /// <returns></returns>
        void Create(T entity);

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool Delete(Tkey id);

        /// <summary>
        /// 按条件删除对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool Delete<Tvalue>(string field, Tvalue value);

        /// <summary>
        /// 按条件删除多个对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        bool DeleteMany<Tvalue>(string field, Tvalue value);

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        void MarkDelete(T entity);

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="id">ID</param>
        void MarkDelete(Tkey id);
    }

    /// <summary>
    /// 默认数据库数据访问层基础接口
    /// 主键类型为string
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IBaseDAL<T> : IBaseDAL<T, string> where T : BaseEntity
    {
    }
}
