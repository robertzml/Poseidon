using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Poseidon.Base
{
    using Poseidon.Common;

    /// <summary>
    /// 数据访问工厂类
    /// </summary>
    /// <typeparam name="T">数据访问接口</typeparam>
    public class RepositoryFactory<T> where T : class
    {
        #region Field
        /// <summary>
        /// 业务类缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 根据配置载入相关数据访问程序集
        /// </summary>
        /// <returns></returns>
        private static T LoadAssembly()
        {
            AppConfig config = new AppConfig();
            string prefix = config.GetAppSetting("DALPrefix");
            prefix = "DAL." + prefix;

            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("IDAL", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name); //reflection create
            return o;
        }
        #endregion //Function

        #region Property
        /// <summary>
        /// 创建或者从缓存中获取对应业务类的实例
        /// </summary>
        public static T Instance
        {
            get
            {
                string cacheKey = typeof(T).FullName;
                T dal = (T)objCache[cacheKey];　 //从缓存读取  
                if (dal == null)
                {
                    lock (syncRoot)
                    {
                        if (dal == null)
                        {
                            dal = LoadAssembly();
                            objCache.Add(cacheKey, dal);
                        }
                    }
                }
                return dal;
            }
        }
        #endregion //Property
    }
}
