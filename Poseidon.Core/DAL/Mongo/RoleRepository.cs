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
    /// 角色数据访问类
    /// </summary>
    internal class RoleRepository : AbstractDALMongo<Role>, IRoleRepository
    {
        #region Constructor
        /// <summary>
        /// 角色数据访问类
        /// </summary>
        public RoleRepository()
        {
            base.Init("core_role");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Role DocToEntity(BsonDocument doc)
        {
            Role entity = new Role();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.Code = doc["code"].ToString();
            entity.Sort = doc["sort"].ToInt32();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            entity.Users = new List<string>();
            if (doc.Contains("users"))
            {
                BsonArray array = doc["users"].AsBsonArray;
                foreach (var item in array)
                {
                    entity.Users.Add(item.ToString());
                }
            }
            entity.Privileges = new List<string>();
            if (doc.Contains("privileges"))
            {
                BsonArray array = doc["privileges"].AsBsonArray;
                foreach (var item in array)
                {
                    entity.Privileges.Add(item.ToString());
                }
            }

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Role entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "code", entity.Code },
                { "sort", entity.Sort },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.Users != null && entity.Users.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Users)
                {
                    array.Add(item);
                }

                doc.Add("users", array);
            }

            if (entity.Privileges != null && entity.Privileges.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Privileges)
                {
                    array.Add(item);
                }

                doc.Add("privileges", array);
            }

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">角色实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(Role entity)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            if (entity.Id == null)
                filter = builder.Eq("code", entity.Code) | builder.Eq("name", entity.Name);
            else
                filter = (builder.Eq("code", entity.Code) | builder.Eq("name", entity.Name)) & builder.Ne("_id", new ObjectId(entity.Id));

            long count = Count(filter);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 关联用户
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="uids">用户ID列表</param>
        public void SetUsers(string id, List<string> uids)
        {
            var doc = new BsonArray();
            foreach (var uid in uids)
            {
                doc.Add(uid);
            }

            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<BsonDocument>.Update.Set("users", doc);

            var result = this.Update(filter, update);
            return;
        }

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">角色ID</param>
        /// <param name="codes">权限代码列表</param>
        public void SetPrivileges(string id, List<string> codes)
        {
            var doc = new BsonArray();
            foreach (var code in codes)
            {
                doc.Add(code);
            }

            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<BsonDocument>.Update.Set("privileges", doc);

            var result = this.Update(filter, update);
            return;
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Role Create(Role entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            return base.Create(entity);
        }
        #endregion //Method
    }
}
