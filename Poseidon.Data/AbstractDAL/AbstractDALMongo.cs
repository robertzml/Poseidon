using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// MongoDB抽象数据访问类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class AbstractDALMongo<T> : IBaseDAL<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// MongoDB数据访问接口
        /// </summary>
        private MongoDb mongo;

        /// <summary>
        /// 默认数据库名称
        /// </summary>
        private readonly string databaseName = "poseidon";

        /// <summary>
        /// 关联集合名称
        /// </summary>
        private string collectionName;
        #endregion //Field

        #region Constructor
        public AbstractDALMongo()
        {
            this.mongo = new MongoDb();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 按默认方式初始化
        /// </summary>
        /// <param name="collectionName">对应集合名称</param>
        /// <remarks>
        /// 由于MongoClient为静态对象，MongoDB只从缓存读取连接字符串并只初始化一次。
        /// </remarks>
        protected virtual void Init(string collectionName)
        {
            Init(collectionName, ConnectionSource.Cache, "ConnectionString");
        }

        /// <summary>
        /// 按设置进行初始化
        /// </summary>
        /// <param name="collectionName">对应集合名称</param>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        private void Init(string collectionName, ConnectionSource source, string key)
        {
            this.collectionName = collectionName;
            this.mongo.OpenDatabase(this.databaseName);
        }

        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected abstract T DocToEntity(BsonDocument doc);

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected abstract BsonDocument EntityToDoc(T entity);
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(string id)
        {
            var doc = this.mongo.FindById(this.collectionName, id);
            if (doc == null)
                return null;

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 根据条件查找单条记录
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var doc = this.mongo.FindOne(this.collectionName, filter);

            if (doc == null)
                return null;

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 根据条件查找单条记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public virtual T FindOne(FilterDefinition<BsonDocument> filter)
        {
            var doc = this.mongo.FindOne(this.collectionName, filter);
            if (doc == null)
                return null;

            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            var docs = this.mongo.FindAll(this.collectionName);

            List<T> data = new List<T>();
            foreach (var doc in docs)
            {
                var entity = DocToEntity(doc);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 按状态查找对象
        /// </summary>
        /// <param name="status">对象状态</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("status", (int)status);
            var docs = this.mongo.Find(this.collectionName, filter);

            List<T> data = new List<T>();
            foreach (var doc in docs)
            {
                var entity = DocToEntity(doc);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 根据条件查找记录
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var docs = this.mongo.Find(this.collectionName, filter);

            List<T> data = new List<T>();
            foreach (var doc in docs)
            {
                var entity = DocToEntity(doc);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 根据条件查找记录
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindList(FilterDefinition<BsonDocument> filter)
        {
            var docs = this.mongo.Find(this.collectionName, filter);

            List<T> data = new List<T>();
            foreach (var doc in docs)
            {
                var entity = DocToEntity(doc);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            return this.mongo.Count(this.collectionName);
        }

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual long Count<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            long count = this.mongo.Count(this.collectionName, filter);
            return count;
        }

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public virtual long Count(FilterDefinition<BsonDocument> filter)
        {
            long count = this.mongo.Count(this.collectionName, filter);
            return count;
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual void Create(T entity)
        {
            var doc = EntityToDoc(entity);
            this.mongo.Insert(this.collectionName, doc);
            return;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual bool Update(T entity)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(entity.Id));
            var doc = EntityToDoc(entity);
            var result = this.mongo.Replace(this.collectionName, filter, doc);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="update">更新条件</param>
        /// <returns></returns>
        public virtual UpdateResult Update(FilterDefinition<BsonDocument> filter, UpdateDefinition<BsonDocument> update)
        {
            var result = this.mongo.Update(this.collectionName, filter, update);
            return result;
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(entity.Id));
            var result = this.mongo.Delete(this.collectionName, filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual bool Delete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var result = this.mongo.Delete(this.collectionName, filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 按条件删除对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual bool Delete<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var result = this.mongo.Delete(this.collectionName, filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 按条件删除多个对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual bool DeleteMany<Tvalue>(string field, Tvalue value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, value);
            var result = this.mongo.DeleteMany(this.collectionName, filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 按条件删除多个对象
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public virtual bool DeleteMany(FilterDefinition<BsonDocument> filter)
        {
            var result = this.mongo.DeleteMany(this.collectionName, filter);
            return result.IsAcknowledged;
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        public void MarkDelete(T entity)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(entity.Id));
            var update = Builders<BsonDocument>.Update.Set("status", (int)EntityStatus.Deleted);

            this.mongo.Update(this.collectionName, filter, update);
        }

        /// <summary>
        /// 标记删除对象
        /// </summary>
        /// <param name="id">ID</param>
        public void MarkDelete(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<BsonDocument>.Update.Set("status", (int)EntityStatus.Deleted);

            this.mongo.Update(this.collectionName, filter, update);
        }
        #endregion //Method
    }
}
