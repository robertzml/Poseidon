using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// 能源模型数据访问类
    /// </summary>
    internal class OrganizationModelRepostiory : IOrganizationModelRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "customModel";
        #endregion //Field

        #region Constructor
        public OrganizationModelRepostiory()
        {
            this.mongo = new BaseDALMongo();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 数据到实体映射
        /// </summary>
        /// <param name="doc">数据</param>
        /// <returns></returns>
        private OrganizationModel DocToEntity(BsonDocument doc)
        {
            OrganizationModel entity = new OrganizationModel();
            entity.Id = doc["_id"].ToString();
            entity.Key = doc["key"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Base = doc["base"].ToString();
            entity.Type = (CustomModelType)doc["type"].ToInt32();
            entity.Remark = doc["remark"].ToString();

            if (doc.Contains("properties"))
            {
                entity.Properties = new List<ModelProperty>();
                BsonArray array = (BsonArray)doc["properties"];
                foreach (var item in array)
                {
                    ModelProperty mp = new ModelProperty();
                    mp.Name = item["name"].ToString();
                    mp.Type = (ModelPropertyType)Enum.Parse(typeof(ModelPropertyType), item["type"].ToString());
                    mp.Remark = item["remark"].ToString();

                    entity.Properties.Add(mp);
                }
            }

            return entity;
        }
        #endregion //Function

        #region Method

        public OrganizationModel FindById(object id)
        {
            throw new NotImplementedException();
        }

        public OrganizationModel FindById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有组织模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<OrganizationModel> FindAll()
        {
            var filter = Builders<BsonDocument>.Filter.Eq("type", (int)CustomModelType.Organization);

            var docs = this.mongo.Find(this.collectionName, filter);

            List<OrganizationModel> models = new List<OrganizationModel>();

            foreach (var item in docs)
            {
                var m = DocToEntity(item);
                models.Add(m);
            }

            return models;
        }

        #endregion //Method

        public ErrorCode Create(OrganizationModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(OrganizationModel entity)
        {
            throw new NotImplementedException();
        }


        public ErrorCode Update(OrganizationModel entity)
        {
            throw new NotImplementedException();
        }

        public OrganizationModel FindByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationModel> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }
    }
}
