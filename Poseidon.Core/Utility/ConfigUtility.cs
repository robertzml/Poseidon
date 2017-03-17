using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.Utility
{
    using MongoDB.Bson;
    using Poseidon.Base.Framework;
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

        /// <summary>
        /// 记住用户名字段名
        /// </summary>
        private static string rememberUserName = "RememberUserName";

        /// <summary>
        /// 记住密码字段名
        /// </summary>
        private static string remeberPassword = "RememberPassword";
        #endregion //Field

        #region Constructor
        static ConfigUtility()
        {
            configBusiness = BusinessFactory<ConfigBusiness>.GetInstance(new object[] { DataBaseType.Sqlite });
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

        /// <summary>
        /// 检查是否已保存用户名
        /// </summary>
        /// <returns></returns>
        public static bool CheckRememberUser()
        {
            return configBusiness.HaveConfig(rememberUserName);
        }

        /// <summary>
        /// 获取保存用户名
        /// </summary>
        /// <returns></returns>
        public static string GetRememberUserName()
        {
            var config = configBusiness.FindByName(rememberUserName);
            return config.Value;
        }

        /// <summary>
        /// 获取保存密码
        /// </summary>
        /// <returns></returns>
        public static string GetRememberPassword()
        {
            var config = configBusiness.FindByName(remeberPassword);
            return config.Value;
        }

        /// <summary>
        /// 保存用户名密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public static void SaveRememberUser(string userName, string password)
        {
            configBusiness.Create(new Config
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = rememberUserName,
                Value = userName,
                Remark = "用户名"
            });

            configBusiness.Create(new Config
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = remeberPassword,
                Value = password,
                Remark = "密码"
            });
        }

        /// <summary>
        /// 更新保存用户名密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public static void UpdateRememberUser(string userName, string password)
        {
            var configName = configBusiness.FindByName(rememberUserName);
            configName.Value = userName;
            configBusiness.Update(configName);

            var configPass = configBusiness.FindByName(remeberPassword);
            configPass.Value = password;
            configBusiness.Update(configPass);
        }

        /// <summary>
        /// 删除保存用户名密码
        /// </summary>
        public static void RemoveRememberUser()
        {
            var configName = configBusiness.FindByName(rememberUserName);
            configBusiness.Delete(configName);

            var configPass = configBusiness.FindByName(remeberPassword);
            configBusiness.Delete(configPass);
        }
        #endregion //Method
    }
}