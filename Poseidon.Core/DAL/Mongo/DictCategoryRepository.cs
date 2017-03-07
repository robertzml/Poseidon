using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 字典分组数据访问类
    /// </summary>
    public class DictCategoryRepository : AbsctractDALMongo<DictCategory>, IDictCategoryRepository
    {
        #region Constructor
        /// <summary>
        /// 字典分组数据访问类
        /// </summary>
        public DictCategoryRepository()
        {
            this.collectionName = "core_dictCategory";
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override DictCategory DocToEntity(BsonDocument doc)
        {
            DictCategory entity = new DictCategory();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Remark = doc["remark"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(DictCategory entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "remark", entity.Remark },
            };

            return doc;
        }
        #endregion //Function
    }
}
