using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// 自定义模型数据访问类
    /// </summary>
    internal class CustomModelRepository : ICustomModelRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "customModel";
        #endregion //Field

        #region Constructor
        public CustomModelRepository()
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
        private CustomModel DocToEntity(BsonDocument doc)
        {
            CustomModel entity = new EnergyModel();
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
        public CustomModel FindById(object id)
        {
            throw new NotImplementedException();
        }

        public CustomModel FindById(string id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 根据某一字段查询
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public CustomModel FindByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var doc = this.mongo.Find(this.collectionName, filter).FirstOrDefault();

            if (doc == null)
                return null;

            var model = DocToEntity(doc);
            return model;
        }


        public IEnumerable<CustomModel> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据类型获取自定义模型
        /// </summary>
        /// <param name="type">模型类型</param>
        /// <returns></returns>
        public IEnumerable<CustomModel> FindByType(CustomModelType type)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("type", (int)type);
            var docs = this.mongo.Find(this.collectionName, filter);

            List<CustomModel> models = new List<CustomModel>();

            foreach (var item in docs)
            {
                var m = DocToEntity(item);
                models.Add(m);
            }

            return models;
        }

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public IEnumerable<CustomModel> FindListByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var docs = this.mongo.Find(this.collectionName, filter);

            List<CustomModel> models = new List<CustomModel>();

            foreach (var item in docs)
            {
                var m = DocToEntity(item);
                models.Add(m);
            }

            return models;
        }

        /// <summary>
        /// 添加自定义模型
        /// </summary>
        /// <param name="entity">模型对象</param>
        /// <returns></returns>
        public ErrorCode Create(CustomModel entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "key", entity.Key },
                { "name", entity.Name },
                { "base", entity.Base },
                { "type", Convert.ToInt32(entity.Type) },
                { "remark", entity.Remark }
            };

            if (entity.Properties != null && entity.Properties.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Properties)
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
            }

            var result = mongo.Insert(this.collectionName, doc);

            return result;
        }

        public ErrorCode Update(CustomModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(CustomModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
