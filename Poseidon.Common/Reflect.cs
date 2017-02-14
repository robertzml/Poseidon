using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Poseidon.Common
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Reflect<T> where T : class
    {
        #region Field
        /// <summary>
        /// 缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new Object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 根据全名和路径构造对象
        /// </summary>
        /// <param name="name">对象全名</param>
        /// <param name="assemblyString">程序集名称</param>
        /// <returns></returns>
        private static T CreateInstance(string name, string assemblyString)
        {
            Assembly assemblyObj = Assembly.Load(assemblyString);
            if (assemblyObj == null)
            {
                throw new ArgumentNullException("sFilePath", string.Format("无法加载sFilePath={0} 的程序集", assemblyString));
            }

            T obj = (T)assemblyObj.CreateInstance(name); //反射创建 
            return obj;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static T Create(string name, string filePath)
        {
            return Create(name, filePath, true);
        }

        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="bCache">是否用缓存</param>
        /// <returns></returns>
        public static T Create(string name, string filePath, bool bCache)
        {
            string cacheKey = name;
            T objType = null;
            if (bCache)
            {
                if (!objCache.ContainsKey(cacheKey))
                {
                    lock (syncRoot)
                    {
                        objType = CreateInstance(cacheKey, filePath);
                        objCache.Add(cacheKey, objType);//缓存数据访问对象
                    }
                }
                else
                {
                    objType = (T)objCache[cacheKey];    //从缓存读取 
                }
            }
            else
            {
                objType = CreateInstance(name, filePath);
            }

            return objType;
        }
        #endregion //Method
    }
}
