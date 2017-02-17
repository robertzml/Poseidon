using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
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
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }
        #endregion //Function
    }
}
