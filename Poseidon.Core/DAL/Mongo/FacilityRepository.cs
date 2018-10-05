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
    /// 设施对象数据访问类
    /// </summary>
    internal class FacilityRepository : AbstractDALMongo<Facility>, IFacilityRepository
    {
        #region Constructor
        /// <summary>
        /// 设施对象数据访问类
        /// </summary>
        public FacilityRepository()
        {
            base.Init("core_facility");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Facility DocToEntity(BsonDocument doc)
        {
            Facility entity = new Facility();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.ModelType = doc["modelType"].ToString();
            entity.DatasetCode = doc["datasetCode"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Facility entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "modelType", entity.ModelType },
                { "datasetCode", entity.DatasetCode },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据模型类型查找设施
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<Facility> FindByModelType(string modelType)
        {
            return FindListByField("modelType", modelType);
        }

        /// <summary>
        /// 根据ID查找设施
        /// </summary>
        /// <param name="facilityIds">设施ID列表</param>
        /// <returns></returns>
        public IEnumerable<Facility> FindWithIds(List<string> facilityIds)
        {
            var ids = facilityIds.Select(r => new ObjectId(r));
            var filter = Builders<BsonDocument>.Filter.In("_id", ids);

            return FindList(filter);
        }
        #endregion //Method
    }
}
