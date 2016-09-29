using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// 对象模型数据访问类
    /// </summary>
    internal class ObjectModelRepository : IObjectModelRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "objectModel";
        #endregion //Field

        #region Constructor
        public ObjectModelRepository()
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
        private ObjectModel DocToEntity(BsonDocument doc)
        {
            ObjectModel entity = new ObjectModel();
            entity.Id = doc["_id"].ToString();
            entity.Key = doc["key"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Base = doc["base"].ToString();
            entity.IsAbstract = doc["isAbstract"].ToBoolean();           
            entity.Remark = doc["remark"].ToString();

            if (doc.Contains("properties"))
            {
                entity.Properties = new List<PoseidonProperty>();
                BsonArray array = (BsonArray)doc["properties"];
                foreach (var item in array)
                {
                    PoseidonProperty mp = new PoseidonProperty();
                    mp.Name = item["name"].ToString();
                    mp.Type = (PoseidonPropertyType)Enum.Parse(typeof(PoseidonPropertyType), item["type"].ToString());
                    mp.Remark = item["remark"].ToString();

                    entity.Properties.Add(mp);
                }
            }

            return entity;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找对象模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ObjectModel FindById(object id)
        {
            return FindById(id.ToString());
        }

        /// <summary>
        /// 根据ID查找对象模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ObjectModel FindById(string id)
        {
            var doc = this.mongo.FindById(this.collectionName, id);

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 查找所有对象模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ObjectModel> FindAll()
        {
            var docs = this.mongo.FindAll(this.collectionName);
            List<ObjectModel> models = new List<ObjectModel>();

            foreach (var item in docs)
            {
                var m = DocToEntity(item);
                models.Add(m);
            }

            return models;
        }

        /// <summary>
        /// 根据字段查询
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public ObjectModel FindByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var doc = this.mongo.Find(this.collectionName, filter).FirstOrDefault();

            if (doc == null)
                return null;

            var model = DocToEntity(doc);
            return model;
        }

        public IEnumerable<ObjectModel> FindByType(ModelType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectModel> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加对象模型
        /// </summary>
        /// <param name="entity">模型实体</param>
        /// <returns></returns>
        public ErrorCode Create(ObjectModel entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "key", entity.Key },
                { "name", entity.Name },
                { "base", entity.Base },
                { "isAbstract", entity.IsAbstract },              
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
                        { "remark", item.Remark ?? "" }
                    };
                    array.Add(d);
                }

                doc.Add("properties", array);
            }

            var result = mongo.Insert(this.collectionName, doc);

            return result;
        }

        public ErrorCode Update(ObjectModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(ObjectModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
