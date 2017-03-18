using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;

    /// <summary>
    /// 基础业务接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IBaseBL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(Tkey id);

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 查找所有正常状态对象
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAllNormal();

        /// <summary>
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        IEnumerable<T> FindByStatus(EntityStatus status);

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        long Count();

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
    /// 基础业务接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IBaseBL<T> : IBaseBL<T, string> where T : BaseEntity
    {
    }
}
