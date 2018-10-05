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
    /// 模型分组对象数据访问类
    /// </summary>
    internal class GroupRepository : AbstractDALMongo<Group>, IGroupRepository
    {
        #region Constructor
        /// <summary>
        /// 组织分组对象访问类
        /// </summary>
        public GroupRepository()
        {
            base.Init("core_group");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Group DocToEntity(BsonDocument doc)
        {
            Group entity = new Group();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            if (doc.Contains("module"))
                entity.Module = doc["module"].ToString();

            if (doc["parentId"] == BsonNull.Value)
                entity.ParentId = null;
            else
                entity.ParentId = doc["parentId"].ToString();

            entity.ModelTypes = new List<string>();
            if (doc.Contains("modelTypes"))
            {
                BsonArray array = doc["modelTypes"].AsBsonArray;
                foreach (var item in array)
                {
                    entity.ModelTypes.Add(item.ToString());
                }
            }

            entity.Items = new List<GroupItem>();
            if (doc.Contains("items"))
            {
                BsonArray array = doc["items"].AsBsonArray;
                foreach (BsonDocument item in array)
                {
                    GroupItem gi = new GroupItem();
                    gi.GroupCode = item.GetValue("groupCode", "").ToString();
                    gi.EntityId = item["entityId"].ToString();
                    gi.ModelType = item.GetValue("modelType", "").ToString();
                    gi.Sort = item["sort"].ToInt32();

                    entity.Items.Add(gi);
                }
            }

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Group entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "module", entity.Module },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.ParentId == null)
                doc.Add("parentId", BsonNull.Value);
            else
                doc.Add("parentId", entity.ParentId);

            if (entity.ModelTypes != null && entity.ModelTypes.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.ModelTypes)
                {
                    array.Add(item);
                }

                doc.Add("modelTypes", array);
            }

            if (entity.Items != null && entity.Items.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Items)
                {
                    array.Add(new BsonDocument
                    {
                        { "groupCode", item.GroupCode },
                        { "entityId", item.EntityId },
                        { "modelType", item.ModelType },
                        { "sort", item.Sort }
                    });
                }

                doc.Add("items", array);
            }

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">分组实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(Group entity)
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

        /// <summary>
        /// 递归载入所有子分组
        /// </summary>
        /// <param name="parentId">父分组ID</param>
        /// <returns></returns>
        private IEnumerable<Group> LoadChildren(string parentId)
        {
            List<Group> data = new List<Group>();
            var children = FindListByField("parentId", parentId);
            data.AddRange(children);

            foreach (var item in children)
            {
                var c = LoadChildren(item.Id);
                data.AddRange(c);
            }

            return data;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 查找所有子分组
        /// </summary>
        /// <param name="id">父分组ID</param>
        /// <returns></returns>
        public IEnumerable<Group> FindAllChildren(string id)
        {
            var data = LoadChildren(id);
            return data;
        }

        /// <summary>
        /// 查找分组及子分组
        /// </summary>
        /// <param name="code">分组代码</param>
        /// <returns></returns>
        public IEnumerable<Group> FindWithChildrenByCode(string code)
        {
            List<Group> data = new List<Group>();
            var parent = base.FindOneByField("code", code);
            if (parent == null)
                return data;

            data.Add(parent);

            var children = LoadChildren(parent.Id);
            data.AddRange(children);

            return data;
        }

        /// <summary>
        /// 绑定模型类型
        /// </summary>
        /// <param name="id">分组ID</param>
        /// <param name="codes">模型类型代码</param>
        public void SetModelTypes(string id, List<string> codes)
        {
            var doc = new BsonArray();
            foreach (var code in codes)
            {
                doc.Add(code);
            }

            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<BsonDocument>.Update.Set("modelTypes", doc);

            var result = this.Update(filter, update);
            return;
        }

        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Group Create(Group entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑分组
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Update(Group entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            return base.Update(entity);
        }
        #endregion //Method
    }
}
