using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.DL;

    /// <summary>
    /// 分组业务访问服务接口
    /// </summary>
    public interface IGroupService : IBaseService<Group>
    {
        /// <summary>
        /// 根据代码查找分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        Group FindByCode(string code);

        /// <summary>
        /// 查找所有子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        IEnumerable<Group> FindAllChildren(string id);

        /// <summary>
        /// 查找分组及子分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        IEnumerable<Group> FindWithChildrenByCode(string code);

        /// <summary>
        /// 查找子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        IEnumerable<Group> FindChildren(string id);

        /// <summary>
        /// 查找包含模型类型的分组
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        IEnumerable<Group> FindByModelType(string modelType);

        /// <summary>
        /// 查找分组及子分组包含组织
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        IEnumerable<GroupItem> FindAllItems(string id);

        /// <summary>
        /// 获取分组关联模型分类
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <remarks>
        /// 默认一个分组只能包含一种模型分类
        /// </remarks>
        /// <returns></returns>
        ModelCategory GetCategory(Group entity);

        /// <summary>
        /// 获取分组项对应实体
        /// </summary>
        /// <param name="groupItem">分组项</param>
        /// <returns></returns>
        ObjectEntity GetItemEntity(GroupItem groupItem);

        /// <summary>
        /// 获取分组项对应实体
        /// </summary>
        /// <param name="groupItems">分组项</param>
        /// <returns></returns>
        IEnumerable<ObjectEntity> GetItemEntities(List<GroupItem> groupItems);

        /// <summary>
        /// 设置关联模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        void SetModelTypes(string id, List<string> codes);

        /// <summary>
        /// 设置分组包含对象
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="items">分组项</param>
        void SetGroupItems(string id, List<GroupItem> items);
    }
}
