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
    internal class UserRepository : AbsctractDALMongo<User>, IUserRepository
    {
        #region Constructor
        /// <summary>
        /// 组织分组对象访问类
        /// </summary>
        public UserRepository()
        {
            this.collectionName = "core_user";
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

            return doc;
        }
        #endregion //Function

        #region Method
        #endregion //Method
    }
}
