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

            Initialize();
        }

        private void Initialize()
        {
            this.db.Connect("mongodb://localhost:27017");
            this.db.GetDatabase("poseidon");
        }

        public IEnumerable<BsonDocument> FindAll(string collectionName)
        {
            var collection = this.db.GetCollection(collectionName);
            var docs = collection.Find(new BsonDocument()).ToList();
            return docs;
        }

        public ErrorCode Insert(string collectionName, BsonDocument doc)
        {
            var collection = this.db.GetCollection(collectionName);
            collection.InsertOne(doc);
            return ErrorCode.Success;
        }
    }
}
