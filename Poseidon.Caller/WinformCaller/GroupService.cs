using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 分组业务访问服务
    /// </summary>
    internal class GroupService : AbstractLocalService<Group>, IGroupService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private GroupBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分组业务访问服务类
        /// </summary>
        public GroupService() : base(BusinessFactory<GroupBusiness>.Instance)
        {
            this.bl = this.baseBL as GroupBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码查找分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        public Group FindByCode(string code)
        {
            return this.bl.FindByCode(code);
        }

        /// <summary>
        /// 查找所有子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<Group> FindAllChildren(string id)
        {
            return this.bl.FindAllChildren(id);
        }

        /// <summary>
        /// 查找分组及子分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        public IEnumerable<Group> FindWithChildrenByCode(string code)
        {
            return this.bl.FindWithChildrenByCode(code);
        }

        /// <summary>
        /// 查找子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<Group> FindChildren(string id)
        {
            return this.bl.FindChildren(id);
        }

        /// <summary>
        /// 查找包含模型类型的分组
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Group> FindByModelType(string modelType)
        {
            return this.bl.FindByModelType(modelType);
        }

        /// <summary>
        /// 查找分组及子分组包含组织
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<GroupItem> FindAllItems(string id)
        {
            return this.bl.FindAllItems(id);
        }

        /// <summary>
        /// 获取分组关联模型分类
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <remarks>
        /// 默认一个分组只能包含一种模型分类
        /// </remarks>
        /// <returns></returns>
        public ModelCategory GetCategory(Group entity)
        {
            return this.bl.GetCategory(entity);
        }

        /// <summary>
        /// 获取分组项对应实体
        /// </summary>
        /// <param name="groupItem">分组项</param>
        /// <returns></returns>
        public ObjectEntity GetItemEntity(GroupItem groupItem)
        {
            return this.bl.GetItemEntity(groupItem);
        }

        /// <summary>
        /// 获取分组项对应实体
        /// </summary>
        /// <param name="groupItems">分组项</param>
        /// <returns></returns>
        public IEnumerable<ObjectEntity> GetItemEntities(List<GroupItem> groupItems)
        {
            return this.bl.GetItemEntities(groupItems);
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="entity">分组对象</param>
        /// <returns></returns>
        public override bool Update(Group entity)
        {
            return this.bl.Update(entity);
        }

        /// <summary>
        /// 设置关联模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        public void SetModelTypes(string id, List<string> codes)
        {
            this.bl.SetModelTypes(id, codes);
        }

        /// <summary>
        /// 设置分组包含对象
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="items">分组项</param>
        public void SetGroupItems(string id, List<GroupItem> items)
        {
            this.bl.SetGroupItems(id, items);
        }
        #endregion //Method
    }
}
