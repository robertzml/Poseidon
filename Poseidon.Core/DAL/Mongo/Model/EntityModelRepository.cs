using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// 实体模型数据访问类
    /// </summary>
    internal class EntityModelRepository : IEntityModelRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "objectModel";
        #endregion //Field

        #region Constructor
        public EntityModelRepository()
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
        private EntityModel DocToEntity(BsonDocument doc)
        {
            EntityModel entity = new EntityModel();
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
        public EntityModel FindById(object id)
        {
            return FindById(id.ToString());
        }

        /// <summary>
        /// 根据ID查找对象模型
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public EntityModel FindById(string id)
        {
            var doc = this.mongo.FindById(this.collectionName, id);

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 查找所有对象模型
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EntityModel> FindAll()
        {
            var docs = this.mongo.FindAll(this.collectionName);
            List<EntityModel> models = new List<EntityModel>();

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
        public EntityModel FindByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var doc = this.mongo.Find(this.collectionName, filter).FirstOrDefault();

            if (doc == null)
                return null;

            var model = DocToEntity(doc);
            return model;
        }

        public IEnumerable<EntityModel> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加对象模型
        /// </summary>
        /// <param name="entity">模型实体</param>
        /// <returns></returns>
        public ErrorCode Create(EntityModel entity)
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

        public ErrorCode Update(EntityModel entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(EntityModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
