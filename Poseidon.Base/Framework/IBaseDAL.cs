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
    public interface IBaseDAL<T> where T : BaseEntity
    {
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(object id);

        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(string id);

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
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value);

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
        ErrorCode Create(T entity);

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        ErrorCode Update(T entity);

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        ErrorCode Delete(T entity);
    }
}
