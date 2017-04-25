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
    /// 建筑对象访问类
    /// </summary>
    internal class BuildingRepository : AbstractDALMongo<Building>, IBuildingRepository
    {
        #region Constructor
        /// <summary>
        /// 建筑对象访问类
        /// </summary>
        public BuildingRepository()
        {
            base.Init("core_building");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Building DocToEntity(BsonDocument doc)
        {
            Building entity = new Building();
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
        protected override BsonDocument EntityToDoc(Building entity)
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
        /// 根据模型类型查找建筑
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Building> FindByModelType(string modelType)
        {
            return FindListByField("modelType", modelType);
        }

        /// <summary>
        /// 根据ID查找建筑
        /// </summary>
        /// <param name="buildingIds">建筑ID列表</param>
        /// <returns></returns>
        public IEnumerable<Building> FindWithIds(List<string> buildingIds)
        {
            var ids = buildingIds.Select(r => new ObjectId(r));
            var filter = Builders<BsonDocument>.Filter.In("_id", ids);

            return FindList(filter);
        }
        #endregion //Method
    }
}
