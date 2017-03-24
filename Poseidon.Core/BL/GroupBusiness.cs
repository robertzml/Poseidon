using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 分组对象业务类
    /// </summary>
    public class GroupBusiness : AbstractBusiness<Group>, IBaseBL<Group>
    {
        #region Field

        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分组对象业务类
        /// </summary>
        public GroupBusiness()
        {
            this.baseDal = RepositoryFactory<IGroupRepository>.Instance;
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
            var entity = this.baseDal.FindOneByField("code", code);
            return entity;
        }

        /// <summary>
        /// 查找所有子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<Group> FindAllChildren(string id)
        {
            var dal = this.baseDal as IGroupRepository;
            return dal.FindAllChildren(id);
        }

        /// <summary>
        /// 查找分组及子分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        public IEnumerable<Group> FindWithChildrenByCode(string code)
        {
            var dal = this.baseDal as IGroupRepository;
            return dal.FindWithChildrenByCode(code);
        }

        /// <summary>
        /// 查找子分组
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<Group> FindChildren(string id)
        {
            var dal = this.baseDal as IGroupRepository;
            return dal.FindListByField("parentId", id);
        }

        /// <summary>
        /// 查找包含模型类型的分组
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Group> FindByModelType(string modelType)
        {
            var dal = this.baseDal as IGroupRepository;
            return dal.FindListByField("modelTypes", modelType);
        }

        /// <summary>
        /// 查找分组及子分组包含组织
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <returns></returns>
        public IEnumerable<GroupItem> FindAllItems(string id)
        {
            var dal = this.baseDal as IGroupRepository;
            List<GroupItem> data = new List<GroupItem>();

            var top = dal.FindById(id);
            data.AddRange(top.Items);

            var children = dal.FindAllChildren(id);
            foreach (var child in children)
            {
                data.AddRange(child.Items);
            }

            data = data.OrderBy(r => r.Sort).ToList();
            return data;
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="entity">分组对象</param>
        /// <returns></returns>
        public override bool Update(Group entity)
        {
            foreach (var item in entity.Items)
            {
                item.GroupCode = entity.Code;
            }
            return base.Update(entity);
        }

        /// <summary>
        /// 设置关联模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        public void SetModelTypes(string id, List<string> codes)
        {
            var dal = this.baseDal as IGroupRepository;
            dal.SetModelTypes(id, codes);

            // set the children's modelTypes field
            var children = dal.FindAllChildren(id);
            foreach (var item in children)
            {
                dal.SetModelTypes(item.Id, codes);
            }
            return;
        }

        /// <summary>
        /// 设置分组包含组织
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="items">分组项</param>
        public void SetOrganizations(string id, List<GroupItem> items)
        {
            var group = this.baseDal.FindById(id);
            foreach (var item in items)
            {
                item.GroupCode = group.Code;
            }
            group.Items = items;

            base.Update(group);
            return;
        }
        #endregion //Method
    }
}
