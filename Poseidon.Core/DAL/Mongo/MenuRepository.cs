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
    /// 菜单对象访问类
    /// </summary>
    internal class MenuRepository : AbstractDALMongo<Menu>, IMenuRepository
    {
        #region Constructor
        /// <summary>
        /// 菜单对象访问类
        /// </summary>
        public MenuRepository()
        {
            base.Init("core_menu");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override Menu DocToEntity(BsonDocument doc)
        {
            Menu entity = new Menu();
            entity.Id = doc["_id"].ToString();
            entity.Name = doc["name"].ToString();
            entity.AssemblyName = doc["assemblyName"].ToString();
            entity.TypeName = doc["typeName"].ToString();
            entity.Glyph = doc["glyph"].ToString();
            entity.LargeGlyph = doc["largeGlyph"].ToString();
            entity.PrivilegeCode = doc["privilegeCode"].ToString();
            entity.Type = doc["type"].ToInt32();
            entity.Sort = doc["sort"].ToInt32();
            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            if (doc.Contains("parentId"))
                entity.ParentId = doc["parentId"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(Menu entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "name", entity.Name },
                { "assemblyName", entity.AssemblyName },
                { "typeName", entity.TypeName },
                { "glyph", entity.Glyph },
                { "largeGlyph", entity.LargeGlyph },
                { "privilegeCode", entity.PrivilegeCode },
                { "type", entity.Type },
                { "sort", entity.Sort },
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            if (entity.ParentId != null)
                doc.Add("parentId", entity.ParentId);

            return doc;
        }
        #endregion //Function
    }
}
