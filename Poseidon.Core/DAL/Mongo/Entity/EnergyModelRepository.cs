using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;
    using Poseidon.Model;

    /// <summary>
    /// 能源模型数据访问类
    /// </summary>
    internal class EnergyModelRepository : IEnergyModelRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "customModel";
        #endregion //Field

        #region Constructor
        public EnergyModelRepository()
        {
            this.mongo = new BaseDALMongo();
        }
        #endregion //Constructor

        #region Function
        private EnergyModel DocToEntity(BsonDocument doc)
        {
            EnergyModel entity = new EnergyModel();
            entity.Id = doc["_id"].ToString();
            entity.Key = doc["key"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Base = doc["base"].ToString();
            entity.Type = (ModelType)doc["type"].ToInt32();
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
        /// <summary>
        /// 根据ID查找能源模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public EnergyModel FindById(object id)
        {
            return FindById(id.ToString());
        }

        /// <summary>
        /// 根据ID查找能源模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public EnergyModel FindById(string id)
        {
            var doc = this.mongo.FindById(this.collectionName, id.ToString());

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 获取所有能源模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EnergyModel> FindAll()
        {
            var docs = this.mongo.FindAll(this.collectionName);
            List<EnergyModel> models = new List<EnergyModel>();

            foreach (var item in docs)
            {
                var m = DocToEntity(item);
                models.Add(m);
            }

            return models;
        }

        /// <summary>
        /// 获取所有能源模型基本属性
        /// </summary>
        /// <returns></returns>
        public List<EnergyModel> FindAllWithMain()
        {
            var data = mongo.FindAll("customModel");

            List<EnergyModel> models = new List<EnergyModel>();
            foreach (var item in data)
            {
                EnergyModel m = new EnergyModel();
                m.Id = item["_id"].ToString();
                m.Key = item["key"].ToString();
                m.Name = item["name"].ToString();
                m.Base = item["base"].ToString();
                m.Type = (ModelType)item["type"].ToInt32();
                m.Remark = item["remark"].ToString();

                models.Add(m);
            }

            return models;
        }

        public ErrorCode Create(EnergyModel obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增能源模型
        /// </summary>
        /// <param name="model">基础属性</param>
        /// <param name="properties">自定义属性</param>
        /// <returns></returns>
        public ErrorCode Create(EnergyModel model, List<ModelProperty> properties)
        {
            BsonDocument doc = new BsonDocument
            {
                { "key", model.Key },
                { "name", model.Name },
                { "base", model.Base },
                { "type", Convert.ToInt32(model.Type) },
                { "remark", model.Remark }
            };

            BsonArray array = new BsonArray();
            foreach (var item in properties)
            {
                BsonDocument d = new BsonDocument
                {
                    { "name", item.Name },
                    { "type", item.Type.ToString() },
                    { "remark", item.Remark }
                };
                array.Add(d);
            }

            doc.Add("properties", array);

            var result = mongo.Insert("customModel", doc);

            return result;
        }


        public ErrorCode Update(EnergyModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(EnergyModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
