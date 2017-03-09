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
        /// <param name="connectionString">连接字符串</param>
        public static void SetConnectionString(string connectionString)
        {
            Config config = new Config
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = "Connection",
                Value = connectionString,
                Remark = "连接字符串"
            };

            configBusiness.Create(config);
        }

        public static string GetConnectionString()
        {
            return "";
        }
        #endregion //Method
    }
}
