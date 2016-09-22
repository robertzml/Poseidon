using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDAL
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// MongoDB数据访问类
    /// </summary>
    public class BaseDALMongo
    {
        #region Field
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private MongoDb db;

        /// <summary>
        /// 默认数据库名称
        /// </summary>
        private string databaseName = "poseidon";
        #endregion //Field

        #region Constructor
        public BaseDALMongo()
        {
            this.db = new MongoDb();

            Initialize();
        }
        #endregion //Constructor

        #region Function
        private void Initialize()
        {
            this.db.Connect();
            this.db.OpenDatabase(this.databaseName);
        }
        #endregion //Function

        #region Method
        public BsonDocument FindById(string collectionName, string _id)
        {
            var collection = this.db.GetCollection(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(_id));

            var doc = collection.Find(filter).First();

            return doc;
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
        #endregion //Method
    }
}
