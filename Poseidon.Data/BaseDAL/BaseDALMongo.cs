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
        /// <summary>
        /// MongoDB数据访问类
        /// </summary>
        public BaseDALMongo()
        {
            this.db = new MongoDb();

            Initialize();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 数据库连接初始化
        /// </summary>
        private void Initialize()
        {
            this.db.Connect();
            this.db.OpenDatabase(this.databaseName);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="_id">ID</param>
        /// <returns></returns>
        public BsonDocument FindById(string collectionName, string _id)
        {
            var collection = this.db.GetCollection(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(_id));

            var doc = collection.Find(filter).First();

            return doc;
        }

        /// <summary>
        /// 查找集合所有记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public IEnumerable<BsonDocument> FindAll(string collectionName)
        {
            var collection = this.db.GetCollection(collectionName);
            var docs = collection.Find(new BsonDocument()).ToList();
            return docs;
        }

        /// <summary>
        /// 根据Filter查找记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public IEnumerable<BsonDocument> Find(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.db.GetCollection(collectionName);
            var docs = collection.Find(filter).ToList();

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
