using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.Utility
{
    using MongoDB.Bson;
    using Poseidon.Base.Framework;
    using Poseidon.Base.Utility;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 配置文件工具类
    /// </summary>
    public static class ConfigUtility
    {
        #region Field
        /// <summary>
        /// 配置业务对象，使用本地Sqlite
        /// </summary>
        private static ConfigBusiness configBusiness;
        #endregion //Field

        #region Constructor
        static ConfigUtility()
        {
            configBusiness = BusinessFactory<ConfigBusiness>.GetInstance(new object[] { "Sqlite" });
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connectionName">字符串名称</param>
        /// <param name="connectionString">连接字符串</param>
        public static void SetConnectionString(string connectionName, string connectionString)
        {
            Config config = new Config
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = connectionName,
                Value = connectionString,
                Remark = "连接字符串"
            };

            configBusiness.Create(config);
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName)
        {
            var config = configBusiness.FindByName(connectionName);
            if (config == null)
                return "";
            else
                return config.Value;
        }
        #endregion //Method
    }
}