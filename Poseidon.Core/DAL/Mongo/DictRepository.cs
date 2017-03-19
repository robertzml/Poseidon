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
    /// 字典数据访问类
    /// </summary>
    internal class DictRepository : AbstractDALMongo<Dict>, IDictRepository
    {
        #region Constructor
        /// <summary>
        /// 字典数据访问类
        /// </summary>
        public DictRepository()
        {
            base.Init("core_dict");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Dict DocToEntity(BsonDocument doc)
        {
            Dict entity = new Dict();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.CategoryId = doc["categoryId"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            entity.Items = new List<DictItem>();
            if (doc.Contains("data"))
            {
                BsonArray array = doc["data"].AsBsonArray;
                foreach (BsonDocument item in array)
                {
                    entity.Items.Add(new DictItem
                    {
                        Key = item["key"].ToInt32(),
                        Value = item["value"].ToString(),
                        Remark = item["remark"].ToString()
                    });
                }
            }

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Dict entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "categoryId", entity.CategoryId },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.Items != null && entity.Items.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Items)
                {
                    BsonDocument sub = new BsonDocument
                    {
                        { "key", item.Key },
                        { "value", item.Value },
                        { "remark", item.Remark }
                    };
                    array.Add(sub);
                }
                doc.Add("data", array);
            }

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        private bool CheckDuplicate(Dict entity)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            if (entity.Id == null)
                filter = builder.Eq("code", entity.Code);
            else
                filter = builder.Eq("code", entity.Code) & builder.Ne("_id", new ObjectId(entity.Id));

            long count = Count(filter);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Dict Create(Dict entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑字典
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Update(Dict entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            return base.Update(entity);
        }
        #endregion //Method
    }
}
