using System;
using System.Collections;
using System.Collections.Generic;
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
    internal class ConfigRepository: AbsctractDALSqlite<Config>, IConfigRepository
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
        /// Hashtable转实体对象
        /// </summary>
        /// <param name="table">Hashtable</param>
        /// <returns></returns>
        protected override Config HashToEntity(Hashtable table)
        {
            return null;
        }

        /// <summary>
        /// Reader转实体对象
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns></returns>
        protected override Config ReaderToEntity(SqlDataReader reader)
        {
            Config entity = new Config();

            //reader.g.GetString()
            ////SmartDataReader reader = new SmartDataReader(dataReader);

            //info.WorkFlowInsID = reader.GetString("WorkFlowInsID");
            //info.WorkFlowID = reader.GetString("WorkFlowID");
            //info.WorkFlowNo = reader.GetString("WorkFlowNo");
            //info.FlowInsCaption = reader.GetString("FlowInsCaption");
            //info.Description = reader.GetString("Description");
            //info.Priority = reader.GetString("Priority");
            //info.Status = reader.GetString("Status");

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
