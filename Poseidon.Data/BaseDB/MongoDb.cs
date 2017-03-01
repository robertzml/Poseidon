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
    internal class MongoDb
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
            string connectionString = GetConnectionString();
            client = new MongoClient(connectionString);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取配置连接字符串
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return AppConfig.GetConnectionString();
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
        #endregion //Method
    }
}
