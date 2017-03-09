using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
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
            string prefix = AppConfig.GetAppSetting("DALPrefix");
            prefix = "DAL." + prefix;

            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("IDAL", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name); //reflection create
            return o;
        }

        /// <summary>
        /// 载入指定数据访问程序集
        /// </summary>
        /// <param name="prefix">数据访问层前缀</param>
        /// <returns></returns>
        private static T LoadAssembly(string prefix)
        {
            prefix = "DAL." + prefix;

            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("IDAL", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name); //reflection create
            return o;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 创建业务类的实例，不缓存
        /// </summary>
        /// <param name="prefix">数据访问层前缀</param>
        /// <returns></returns>
        public static T GetInstance(string prefix)
        {
            T dal = null;
            if (dal == null)
            {
                lock (syncRoot)
                {
                    if (dal == null)
                    {
                        dal = LoadAssembly(prefix);
                    }
                }
            }
            return dal;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 创建或者从缓存中获取对应业务类的实例
        /// </summary>
        public static T Instance
        {
            get
            {
                string cacheKey = typeof(T).FullName;
                //从缓存读取
                T dal = (T)objCache[cacheKey];
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
