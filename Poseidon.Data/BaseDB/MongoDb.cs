using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Poseidon.Data.BaseDB
{

    public class MongoDb
    {
        private MongoClient client;

        private IMongoDatabase database;

        public void Connect()
        {
            this.client = new MongoClient();
            //client.GetDatabase();
        }

        public void Connec(string connectionString)
        {
            this.client = new MongoClient(connectionString);

        }

        public void GetDatabase(string dbName)
        {
            this.database = this.client.GetDatabase(dbName);
        }

        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);
            return collection;
        }
    }
}
