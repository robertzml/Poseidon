﻿using System;
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
    public class GroupBusiness : AbstractBusiness<Group>
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
        /// 设置下属组织
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="organizations">组织ID</param>
        public void SetOrganizations(string id, List<string> organizations)
        {
            var dal = this.baseDal as IGroupRepository;
            dal.SetOrganizations(id, organizations);
            return;
        }
        #endregion //Method
    }
}
