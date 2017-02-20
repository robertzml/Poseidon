using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 组织对象访问类
    /// </summary>
    internal class OrganizationRepository : AbsctractDALMongo<Organization>, IOrganizationRepository
    {
        #region Constructor
        /// <summary>
        /// 组织对象访问类
        /// </summary>
        public OrganizationRepository()
        {
            this.collectionName = "core_organization";
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Organization DocToEntity(BsonDocument doc)
        {
            Organization entity = new Organization();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.ModelType = doc["modelType"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            if (doc.Contains("parentId"))
                entity.ParentId = doc["parentId"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Organization entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "modelType", entity.ModelType },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.ParentId != null)
                doc.Add("parentId", entity.ParentId);

            return doc;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据模型类型查找组织
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindByModelType(string modelType)
        {
            return FindListByField("modelType", modelType);
        }

        /// <summary>
        /// 根据ID查找组织
        /// </summary>
        /// <param name="organizationIds">组织ID列表</param>
        /// <returns></returns>
        public IEnumerable<Organization> FindWithIds(List<string> organizationIds)
        {
            var ids = organizationIds.Select(r => new ObjectId(r));
            var filter = Builders<BsonDocument>.Filter.In("_id", ids);

            return FindList(filter);
        }
        #endregion //Method
    }
}
