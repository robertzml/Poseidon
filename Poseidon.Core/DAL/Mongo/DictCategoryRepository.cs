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
    internal class DictCategoryRepository : AbstractDALMongo<DictCategory>, IDictCategoryRepository
    {
        #region Constructor
        /// <summary>
        /// 字典分组数据访问类
        /// </summary>
        public DictCategoryRepository()
        {
            base.Init("core_dictCategory");
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
            entity.Status = doc["status"].ToInt32();

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
                { "status", entity.Status }
            };

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">分组实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(DictCategory entity)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            if (entity.Id == null)
                filter = builder.Eq("name", entity.Name);
            else
                filter = builder.Eq("name", entity.Name) & builder.Ne("_id", new ObjectId(entity.Id));

            long count = Count(filter);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override void Create(DictCategory entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateName);

            entity.Status = 0;
            base.Create(entity);
            return;
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Update(DictCategory entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateName);

            return base.Update(entity);
        }
        #endregion //Method
    }
}
