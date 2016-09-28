using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo.Model
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

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
            entity.Type = (ModelType)doc["type"].ToInt32();
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

        public IEnumerable<ObjectModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public ObjectModel FindByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectModel> FindByType(ModelType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ObjectModel> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(ObjectModel entity)
        {
            throw new NotImplementedException();
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
