﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// MongoDB抽象数据访问类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbsctractDALMongo<T> : IBaseDAL<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// MongoDB数据访问接口
        /// </summary>
        private BaseDALMongo mongo;

        /// <summary>
        /// 关联集合名称
        /// </summary>
        protected string collectionName;
        #endregion //Field

        #region Constructor
        public AbsctractDALMongo()
        {
            this.mongo = new BaseDALMongo();
        }
        #endregion //Constructor

        #region Function
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
        public virtual T FindById(object id)
        {
            var doc = this.mongo.FindById(this.collectionName, id.ToString());
            var entity = DocToEntity(doc);
            return entity;
        }

        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(string id)
        {
            var doc = this.mongo.FindById(this.collectionName, id);
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

        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
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

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
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

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}