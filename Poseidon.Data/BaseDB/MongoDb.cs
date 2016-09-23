using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDB
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Common;

    /// <summary>
    /// MongoDB 数据库访问类
    /// </summary>
    public class MongoDb
    {
        #region Field
        /// <summary>
        /// MongoDB客户端连接
        /// </summary>
        private MongoClient client;

        /// <summary>
        /// 数据库对象
        /// </summary>
        private IMongoDatabase database;
        #endregion //Field

        #region Method
        /// <summary>
        /// 打开默认连接
        /// </summary>
        public void Connect()
        {
            string connectionString = AppConfig.GetConnectionString();
            this.client = new MongoClient(connectionString);
        }

        /// <summary>
        /// 打开指定连接
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public void Connect(string connectionString)
        {
            this.client = new MongoClient(connectionString);
        }

        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <param name="dbName">数据库名称</param>
        public void OpenDatabase(string dbName)
        {
            this.database = this.client.GetDatabase(dbName);
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
        #endregion //Method
    }
}
