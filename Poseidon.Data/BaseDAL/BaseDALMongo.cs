﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDAL
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.System;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// MongoDB数据访问类
    /// </summary>
    internal class BaseDALMongo
    {
        #region Field
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private MongoDb db;

        /// <summary>
        /// 默认数据库名称
        /// </summary>
        private readonly string databaseName = "poseidon";
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
        /// 根据Filter查找单条记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public BsonDocument FindOne(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.db.GetCollection(collectionName);
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

        /// <summary>
        /// 根据Filter查找记录数量
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public long Count(string collectionName, FilterDefinition<BsonDocument> filter)
        {
            var collection = this.db.GetCollection(collectionName);
            return collection.Count(filter);
        }

        /// <summary>
        /// 插入记录
        /// </summary>
        /// <param name="collectionName">集合名称</param>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        public void Insert(string collectionName, BsonDocument doc)
        {
            var collection = this.db.GetCollection(collectionName);
            collection.InsertOne(doc);
            return;
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
            var collection = this.db.GetCollection(collectionName);
            var result = collection.UpdateOne(filter, update);
            return result;
        }

        public void Upsert(string collectionName, FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            //var collection = this.db.GetCollection(collectionName);
            //UpdateOptions option = new UpdateOptions { IsUpsert = true };
            //collection.UpdateOne(filter, update, option);
            //collection.in
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
            var collection = this.db.GetCollection(collectionName);
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
            var collection = this.db.GetCollection(collectionName);
            DeleteResult result = collection.DeleteOne(filter);
            return result;
        }
        #endregion //Method
    }
}
