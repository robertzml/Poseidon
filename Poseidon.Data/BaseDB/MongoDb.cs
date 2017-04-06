using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDB
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.System;
    using Poseidon.Common;

    /// <summary>
    /// MongoDB 数据库访问类
    /// </summary>
    internal class MongoDb : AbstractDB
    {
        #region Field
        /// <summary>
        /// MongoDB客户端连接
        /// </summary>
        private static MongoClient client = null;

        /// <summary>
        /// 数据库对象
        /// </summary>
        private IMongoDatabase database;
        #endregion //Field

        #region Constructor
        static MongoDb()
        {
            string connectionString = GetConnectionFromCache();
            client = new MongoClient(connectionString);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        protected override string GetConnectionString()
        {
            return "mongodb://localhost:27017";
        }

        /// <summary>
        /// 获取配置连接字符串
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionStringFromConfig()
        {
            return AppConfig.GetConnectionString();
        }

        /// <summary>
        /// 从缓存获取连接字符串
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionFromCache()
        {
            if (!Cache.Instance.ContainKey("ConnectionString"))
                throw new PoseidonException(ErrorCode.DatabaseConnectionNotFound);
            else
                return Cache.Instance["ConnectionString"].ToString();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        public void OpenDatabase(string dbName)
        {
            this.database = client.GetDatabase(dbName);
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public IMongoCollection<BsonDocument> GetCollection(string collectionName)
        {
            var collection = this.database.GetCollection<BsonDocument>(collectionName);
            return collection;
        }

        /// <summary>
        /// 根据ID查找记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="_id">ID</param>
        /// <returns></returns>
        public BsonDocument FindById(string collectionName, string _id)
        {
            var collection = this.GetCollection(collectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(_id));

            var result = collection.Find(filter);
            if (result.Count() == 0)
                return null;

            var doc = result.First();
            return doc;
        }

        /// <summary>
        /// 根据Filter查找单条记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public BsonDocument FindOne(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.GetCollection(collectionName);
            var result = collection.Find(filter);
            if (result.Count() == 0)
                return null;

            var doc = result.First();
            return doc;
        }

        /// <summary>
        /// 查找集合所有记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public IEnumerable<BsonDocument> FindAll(string collectionName)
        {
            var collection = this.GetCollection(collectionName);
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
            var collection = this.GetCollection(collectionName);
            var docs = collection.Find(filter).ToList();

            return docs;
        }

        /// <summary>
        /// 查找所有记录数据
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <returns></returns>
        public long Count(string collectionName)
        {
            var collection = this.GetCollection(collectionName);
            return collection.Count(new BsonDocument());
        }

        /// <summary>
        /// 根据Filter查找记录数量
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public long Count(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.GetCollection(collectionName);
            return collection.Count(filter);
        }

        /// <summary>
        /// 聚合查找
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="match">Match条件</param>
        /// <param name="group">Group条件</param>
        /// <returns></returns>
        public IEnumerable<BsonDocument> Aggregate(string collectionName, FilterDefinition<BsonDocument> match, ProjectionDefinition<BsonDocument, BsonDocument> group)
        {
            var collection = this.GetCollection(collectionName);
            return collection.Aggregate().Match(match).Group(group).ToList();
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        public BsonDocument Insert(string collectionName, BsonDocument doc)
        {
            var collection = this.GetCollection(collectionName);
            collection.InsertOne(doc);
            return doc;
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        public UpdateResult Update(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var collection = this.GetCollection(collectionName);
            var result = collection.UpdateOne(filter, update);
            return result;
        }

        /// <summary>
        /// 替换记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <param name="doc">更新文档</param>
        /// <returns></returns>
        public ReplaceOneResult Replace(string collectionName, FilterDefinition<BsonDocument> filter, BsonDocument doc)
        {
            var collection = this.GetCollection(collectionName);
            ReplaceOneResult result = collection.ReplaceOne(filter, doc);
            return result;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public DeleteResult Delete(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.GetCollection(collectionName);
            DeleteResult result = collection.DeleteOne(filter);
            return result;
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public DeleteResult DeleteMany(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.GetCollection(collectionName);
            DeleteResult result = collection.DeleteMany(filter);
            return result;
        }
        #endregion //Method
    }
}
