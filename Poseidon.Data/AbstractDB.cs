using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using Poseidon.Common;

    /// <summary>
    /// 抽象数据库访问类
    /// </summary>
    public abstract class AbstractDB
    {
        #region Method
        /// <summary>
        /// 载入数据库配置信息
        /// </summary>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        /// <returns></returns>
        public virtual string LoadDbConfig(ConnectionSource source, string key)
        {
            string cs = "";
            switch (source)
            {
                case ConnectionSource.Default:
                    cs = AppConfig.GetConnectionString();
                    break;
                case ConnectionSource.Config:
                    cs = AppConfig.GetConnectionString(key);
                    break;
                case ConnectionSource.Cache:
                    cs = Cache.Instance[key].ToString();
                    break;
            }

            return cs;          
        }
        #endregion //Method
    }
}
