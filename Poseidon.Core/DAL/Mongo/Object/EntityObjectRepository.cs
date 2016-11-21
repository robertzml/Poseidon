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
    /// 实体对象数据访问类
    /// </summary>
    internal class EntityObjectRepository : IEntityObjectRepository
    {
        #region Field
        private BaseDALMongo mongo;

        /// <summary>
        /// 集合名称
        /// </summary>
        private string collectionName = "entityObject";
        #endregion //Field

        #region Constructor
        public EntityObjectRepository()
        {
            this.mongo = new BaseDALMongo();
        }
        #endregion //Constructor

        #region Method


        public IEnumerable<EntityObject> FindAll()
        {
            throw new NotImplementedException();
        }

        public EntityObject FindByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public EntityObject FindById(string id)
        {
            throw new NotImplementedException();
        }

        public EntityObject FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntityObject> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加实体对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public ErrorCode Create(EntityObject entity)
        {
            BsonDocument doc = new BsonDocument();

            foreach (var item in entity.Fields)
            {
                doc.Add(item, (BsonValue)entity[item]);
            }

            var result = mongo.Insert(entity.CollectionName, doc);

            return result;
        }


        public ErrorCode Update(EntityObject entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(EntityObject entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
