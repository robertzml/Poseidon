using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Poseidon.Common
{
    /// <summary>
    /// 配置文件管理类
    /// </summary>
    public static class AppConfig
    {
        #region Field
        /// <summary>
        /// 配置文件对象
        /// </summary>
        private static Configuration config;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 配置文件管理类
        /// </summary>
        static AppConfig()
        {
            string webconfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config");
            string appConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.config");

            string filePath;
            if (File.Exists(webconfig))
            {
                filePath = webconfig;
            }
            else if (File.Exists(appConfig))
            {
                filePath = appConfig;
            }
            else
            {
                throw new ArgumentNullException("没有找到Web.config文件或者App.config文件, 请指定配置文件");
            }

            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = filePath;

            config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取设置参数
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            foreach (string item in config.AppSettings.Settings.AllKeys)
            {
                if (item == key)
                {
                    return config.AppSettings.Settings[key].Value.ToString();
                }
            }

            return "";
        }

        /// <summary>
        /// 获取默认配置连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string key = GetAppSetting("DbConnection");
            return GetConnectionString(key);
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <param name="key">连接字符串键</param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
            if (config.ConnectionStrings.ConnectionStrings[key] != null)
                return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
            else
                return "";
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static string ApplicationName
        {
            get
            {
                return GetAppSetting("ApplicationName");
            }
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public static string DbType
        {
            get
            {
                return GetAppSetting("DbType");
            }
        }

        /// <summary>
        /// 数据库连接字符串键值
        /// </summary>
        public static string DbConnection
        {
            get
            {
                return GetAppSetting("DbConnection");
            }
        }
        #endregion //Property
    }
}
