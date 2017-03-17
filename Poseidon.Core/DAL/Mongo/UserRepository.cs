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
    /// 用户对象数据访问类
    /// </summary>
    internal class UserRepository : AbstractDALMongo<User>, IUserRepository
    {
        #region Field
        /// <summary>
        /// 用户注册初始化时间
        /// </summary>
        private readonly DateTime initialTime = new DateTime(2015, 1, 1);
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 用户对象数据访问类
        /// </summary>
        public UserRepository()
        {
            base.Init("core_user");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override User DocToEntity(BsonDocument doc)
        {
            User entity = new User();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.UserName = doc["userName"].ToString();
            entity.Password = doc["password"].ToString();
            entity.LastLoginTime = doc["lastLoginTime"].ToLocalTime();
            entity.CurrentLoginTime = doc["currentLoginTime"].ToLocalTime();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            entity.Roles = new List<string>();
            if (doc.Contains("roles"))
            {
                BsonArray array = doc["roles"].AsBsonArray;
                foreach (var item in array)
                {
                    entity.Roles.Add(item.ToString());
                }
            }

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(User entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "userName", entity.UserName },
                { "password", entity.Password },
                { "lastLoginTime", entity.LastLoginTime },
                { "currentLoginTime", entity.CurrentLoginTime },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.Roles != null && entity.Roles.Count > 0)
            {
                BsonArray array = new BsonArray();
                foreach (var item in entity.Roles)
                {
                    array.Add(item);
                }

                doc.Add("roles", array);
            }

            return doc;
        }

        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        private bool CheckDuplicate(User entity)
        {
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;

            if (entity.Id == null)
                filter = builder.Eq("userName", entity.UserName);
            else
                filter = builder.Eq("userName", entity.UserName) & builder.Ne("_id", new ObjectId(entity.Id));

            long count = Count(filter);
            if (count > 0)
                return false;
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="ids">用户ID列表</param>
        /// <returns></returns>
        public IEnumerable<User> FindWithIds(List<string> ids)
        {
            var oids = ids.Select(r => new ObjectId(r));
            var filter = Builders<BsonDocument>.Filter.In("_id", oids);

            return FindList(filter);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户实体</param>
        public override void Create(User entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateName);

            entity.LastLoginTime = this.initialTime;
            entity.CurrentLoginTime = this.initialTime;
            entity.Status = 0;

            base.Create(entity);
        }
        #endregion //Method
    }
}
