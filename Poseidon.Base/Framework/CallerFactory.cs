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
        /// 缓存
        /// </summary>
        private static Cache objCache = Cache.Instance;

        /// <summary>
        /// 服务类缓存
        /// </summary>
        //private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 访问类型字符串转换
        /// </summary>
        /// <param name="callerType">访问类型</param>
        /// <returns></returns>
        private static string CallerTypeToString(CallerType callerType)
        {
            switch (callerType)
            {
                case CallerType.Win:
                    return "WinformCaller";
                case CallerType.WebApi:
                    return "WebApiCaller";
                case CallerType.Wcf:
                    return "WcfCaller";
            }

            return "";
        }

        /// <summary>
        /// 载入指定服务访问程序集
        /// </summary>
        /// <param name="prefix">服务访问前缀</param>
        /// <returns></returns>
        private static T LoadAssembly(string prefix)
        {
            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1);

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("Facade", prefix).Replace(name, insName);

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name, false);
            return o;
        }

        /// <summary>
        /// 根据配置载入相关服务访问程序集
        /// </summary>
        /// <returns></returns>
        private static T LoadAssembly()
        {
            string callerType = Cache.Instance["CallerType"].ToString();
            string prefix = "";
            if (callerType == "win")
                prefix = "WinformCaller";
            else if (callerType == "webapi")
                prefix = "WebApiCaller";
            else if (callerType == "wcf")
                prefix = "WcfCaller";

            string name = typeof(T).Name;
            string insName = name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("Facade", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name, false); //reflection create
            if (o == null)
                throw new PoseidonException(ErrorCode.ObjectNotCreate);
            return o;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 创建服务类的实例，不缓存
        /// </summary>
        /// <param name="callerType">服务访问层前缀</param>
        /// <returns></returns>
        public static T GetInstance(CallerType callerType)
        {
            string p = CallerTypeToString(callerType);
            T dal = LoadAssembly(p);
            return dal;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 创建或者从缓存中获取对应服务类的实例
        /// </summary>
        public static T Instance
        {
            get
            {
                string cacheKey = typeof(T).FullName;
                if (objCache.ContainKey(cacheKey))
                {
                    return (T)objCache[cacheKey];
                }
                else
                {
                    lock (syncRoot)
                    {
                        if (objCache.ContainKey(cacheKey))
                        {
                            return (T)objCache[cacheKey];
                        }
                        else
                        {
                            T call = LoadAssembly();
                            objCache.Add(cacheKey, call);
                            return call;
                        }
                    }
                }
            }
        }
        #endregion //Property
    }
}
