using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Sqlite
{
    using Poseidon.Base.System;
    using Poseidon.Data;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using System.Data.SqlClient;

    /// <summary>
    /// 配置数据访问类
    /// </summary>
    internal class ConfigRepository : AbsctractDALSqlite<Config>, IConfigRepository
    {
        #region Constructor
        /// <summary>
        /// 字典数据访问类
        /// </summary>
        public ConfigRepository()
        {
            this.tableName = "Config";
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// Reader转实体对象
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns></returns>
        protected override Config ReaderToEntity(SQLiteDataReader reader)
        {
            Config entity = new Config();

            entity.Id = reader["id"].ToString();
            entity.Name = reader["name"].ToString();
            entity.Value = reader["value"].ToString();
            entity.Remark = reader["remark"].ToString();

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Config entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("Name", entity.Name);
            table.Add("Value", entity.Value);
            table.Add("Remark", entity.Remark);

            return table;
        }
        #endregion //Function
    }
}
