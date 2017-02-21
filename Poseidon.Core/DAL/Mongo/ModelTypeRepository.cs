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
    /// 模型类型数据访问类
    /// </summary>
    internal class ModelTypeRepository : AbsctractDALMongo<ModelType>, IModelTypeRepository
    {
        #region Constructor
        /// <summary>
        /// 组织分组对象访问类
        /// </summary>
        public ModelTypeRepository()
        {
            this.collectionName = "core_modelType";
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override ModelType DocToEntity(BsonDocument doc)
        {
            ModelType entity = new ModelType();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(ModelType entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        private bool CheckDuplicate(ModelType entity)
        {
            long count = Count<string>("code", entity.Code);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 添加模型类型
        /// </summary>
        /// <param name="entity">实体对象</param>
        public override void Create(ModelType entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            base.Create(entity);
        }

        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public ModelType FindByCode(string code)
        {
            var data = FindOneByField("code", code);
            return data;
        }

        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="codes">代码列表</param>
        /// <returns></returns>
        public IEnumerable<ModelType> FindWithCodes(List<string> codes)
        {
            var filter = Builders<BsonDocument>.Filter.In("code", codes);
            return FindList(filter);
        }
        #endregion //Method
    }
}
