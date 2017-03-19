using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.System;
    using Poseidon.Common;

    /// <summary>
    /// 服务调用工厂类
    /// </summary>
    public class CallerFactory<T> where T : class
    {
        #region Field
        /// <summary>
        /// 服务类缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 载入指定数据访问程序集
        /// </summary>
        /// <param name="prefix">数据访问层前缀</param>
        /// <returns></returns>
        private static T LoadAssembly(string prefix)
        {
            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1);

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("Facade", prefix).Replace(name, insName);

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name);
            return o;
        }

        /// <summary>
        /// 根据配置载入相关服务访问程序集
        /// </summary>
        /// <returns></returns>
        private static T LoadAssembly()
        {
            string callerType = AppConfig.CallerType;
            string prefix = "";
            if (callerType == "win")
                prefix = "WinformCaller";
            else if (callerType == "webapi")
                prefix = "WebApiCaller";

            string name = typeof(T).Name;
            string insName = name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("Facade", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name); //reflection create
            if (o == null)
                throw new PoseidonException(ErrorCode.ObjectNotCreate);
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
                T call = (T)objCache[cacheKey];
                if (call == null)
                {
                    lock (syncRoot)
                    {
                        if (call == null)
                        {
                            //反射创建，并缓存
                            call = LoadAssembly();
                            objCache.Add(cacheKey, call);
                        }
                    }
                }
                return call;
            }
        }
        #endregion //Property
    }
}
