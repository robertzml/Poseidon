using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base.Framework;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 文件对象数据访问类
    /// </summary>
    internal class FileRepository : AbstractDALMongo<File>, IFileRepository
    {
        #region Constructor
        /// <summary>
        /// 文件对象数据访问类
        /// </summary>
        public FileRepository()
        {
            base.Init("core_file");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override File DocToEntity(BsonDocument doc)
        {
            File entity = new File();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.ModelType = doc["modelType"].ToString();
            entity.FileName = doc["fileName"].ToString();
            entity.Extension = doc["extension"].ToString();
            entity.ContentType = doc["contentType"].ToString();
            entity.Size = doc["size"].ToInt32();
            entity.Mount = doc["mount"].ToString();
            entity.Type = doc["type"].ToInt32();
            entity.DatasetCode = doc["datasetCode"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            var createBy = doc["createBy"].ToBsonDocument();
            entity.CreateBy = new UpdateStamp
            {
                UserId = createBy["userId"].ToString(),
                Name = createBy["name"].ToString(),
                Time = createBy["time"].ToLocalTime()
            };

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(File entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "modelType", entity.ModelType },
                { "fileName", entity.FileName },
                { "extension", entity.Extension },
                { "contentType", entity.ContentType },
                { "size", entity.Size },
                { "mount", entity.Mount },
                { "type", entity.Type },
                { "datasetCode", entity.DatasetCode },
                { "createBy", new BsonDocument {
                    { "userId", entity.CreateBy.UserId },
                    { "name", entity.CreateBy.Name },
                    { "time", entity.CreateBy.Time }
                }},
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据模型类型查找文件
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<File> FindByModelType(string modelType)
        {
            return FindListByField("modelType", modelType);
        }

        /// <summary>
        /// 根据ID查找文件
        /// </summary>
        /// <param name="fileIds">文件ID列表</param>
        /// <returns></returns>
        public IEnumerable<File> FindWithIds(List<string> fileIds)
        {
            var ids = fileIds.Select(r => new ObjectId(r));
            var filter = Builders<BsonDocument>.Filter.In("_id", ids);

            return FindList(filter);
        }
        #endregion //Method
    }
}
