using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    using Poseidon.Common;

    /// <summary>
    /// 业务工厂类
    /// </summary>
    /// <typeparam name="T">业务对象</typeparam>
    public class BusinessFactory<T> where T : class
    {
        #region Field
        /// <summary>
        /// 缓存
        /// </summary>
        private static Cache objCache = Cache.Instance;

        /// <summary>
        /// 业务类缓存
        /// </summary>
        //private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Method
        /// <summary>
        /// 创建对应业务类的实例，不缓存
        /// </summary>
        /// <returns></returns>
        public static T GetInstance()
        {
            T bll = Reflect<T>.Create(typeof(T).FullName, typeof(T).Assembly.GetName().Name, false);
            return bll;
        }

        /// <summary>
        /// 创建对应业务类的实例，不缓存
        /// </summary>
        /// <param name="args">构造函数参数</param>
        /// <returns></returns>
        public static T GetInstance(object[] args)
        {
            T bll = Reflect<T>.Create(typeof(T).FullName, typeof(T).Assembly.GetName().Name, args, false);
            return bll;
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
                            T bll = Reflect<T>.Create(typeof(T).FullName, typeof(T).Assembly.GetName().Name, false);
                            objCache.Add(cacheKey, bll);

                            return bll;
                        }
                    }
                }
            }
        }
        #endregion //Property
    }
}
