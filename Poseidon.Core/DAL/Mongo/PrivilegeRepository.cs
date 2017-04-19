using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 权限数据访问类
    /// </summary>
    internal class PrivilegeRepository : AbstractDALMongo<Privilege>, IPrivilegeRepository
    {
        #region Constructor
        /// <summary>
        /// 权限数据访问类
        /// </summary>
        public PrivilegeRepository()
        {
            base.Init("core_privilege");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Privilege DocToEntity(BsonDocument doc)
        {
            Privilege entity = new Privilege();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.Action = doc["action"].ToInt32();
            entity.Sort = doc["sort"].ToInt32();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            if (doc["parentId"] == BsonNull.Value)
                entity.ParentId = null;
            else
                entity.ParentId = doc["parentId"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Privilege entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "action", entity.Action },
                { "sort", entity.Sort },
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
        /// <param name="entity">权限实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(Privilege entity)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            if (entity.Id == null)
                filter = builder.Eq("code", entity.Code) | builder.Eq("name", entity.Name);
            else
                filter = (builder.Eq("code", entity.Code) | builder.Eq("name", entity.Name)) & builder.Ne("_id", new ObjectId(entity.Id));

            long count = Count(filter);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Privilege Create(Privilege entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            return base.Create(entity);
        }
        #endregion //Method
    }
}
