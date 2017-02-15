using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using MongoDB.Bson;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
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

        public virtual T FindByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual ErrorCode Create(T entity)
        {
            var doc = EntityToDoc(entity);
            return this.mongo.Insert(this.collectionName, doc);
        }

        public virtual ErrorCode Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual ErrorCode Delete(T entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
