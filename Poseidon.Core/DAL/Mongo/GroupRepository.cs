using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Base.System;

    /// <summary>
    /// 分组对象数据访问类
    /// </summary>
    internal class GroupRepository : AbsctractDALMongo<Group>, IGroupRepository
    {
        #region Constructor
        /// <summary>
        /// 组织分组对象访问类
        /// </summary>
        public GroupRepository()
        {
            this.collectionName = "core_group";
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Group DocToEntity(BsonDocument doc)
        {
            Group entity = new Group();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.ParentId = doc["parentId"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Group entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.ParentId == null)
                doc.Add("parentId", BsonNull.Value);
            else
                doc.Add("parentId", entity.ParentId);

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">分组实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(Group entity)
        {
            long count = Count<string>("code", entity.Code);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override ErrorCode Create(Group entity)
        {
            if (!CheckDuplicate(entity))
                return ErrorCode.DuplicateCode;

            return base.Create(entity);
        }
        #endregion //Method
    }
}
