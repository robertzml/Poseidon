using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDAL
{
    using MongoDB.Bson;
    using MongoDB.Driver;

    using Poseidon.Base.Entity;
    using Poseidon.Data.BaseDB;

    public class BaseDALMongo
    {
        private MongoDb db;

        public BaseDALMongo()
        {
            this.db = new MongoDb();
        }

        public ErrorCode Insert(string collectionName, BsonDocument doc)
        {
            var collection = this.db.GetCollection(collectionName);
            collection.InsertOne(doc);
            return ErrorCode.Error;
        }
    }
}
