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
        private static Cache objCache = Cache.Instance;

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
                throw new ArgumentNullException("assemblyString", string.Format("无法加载AssemblyString = {0} 的程序集", assemblyString));
            }

            //反射创建
            T obj = (T)assemblyObj.CreateInstance(name);
            return obj;
        }

        /// <summary>
        /// 根据全名,路径,参数构造对象
        /// </summary>
        /// <param name="name">对象全名</param>
        /// <param name="assemblyString">程序集名称</param>
        /// <param name="args">构造函数参数</param>
        /// <returns></returns>
        private static T CreateInstance(string name, string assemblyString, object[] args)
        {
            Assembly assemblyObj = Assembly.Load(assemblyString);
            if (assemblyObj == null)
            {
                throw new ArgumentNullException("assemblyString", string.Format("无法加载AssemblyString = {0} 的程序集", assemblyString));
            }

            //反射创建
            T obj = (T)assemblyObj.CreateInstance(name, false, BindingFlags.Default, null, args, null, null);
            return obj;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="assemblyString">程序集名称</param>
        /// <returns></returns>
        public static T Create(string name, string assemblyString)
        {
            return Create(name, assemblyString, true);
        }

        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="assemblyString">程序集名称</param>
        /// <param name="bCache">是否用缓存</param>
        /// <returns></returns>
        public static T Create(string name, string assemblyString, bool bCache)
        {
            string cacheKey = name;
            T objType = null;
            if (bCache)
            {
                if (objCache.ContainKey(cacheKey))
                {
                    //从缓存读取
                    objType = (T)objCache[cacheKey];
                }
                else
                {
                    lock (syncRoot)
                    {
                        if (objCache.ContainKey(cacheKey))
                        {
                            objType = (T)objCache[cacheKey];
                        }
                        else
                        {
                            objType = CreateInstance(cacheKey, assemblyString);
                            //缓存数据访问对象
                            objCache.Add(cacheKey, objType);
                        }
                    }
                }
            }
            else
            {
                objType = CreateInstance(name, assemblyString);
            }

            return objType;
        }

        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="assemblyString">程序集名称</param>
        /// <param name="args">构造函数参数</param>
        /// <param name="bCache">是否用缓存</param>
        /// <returns></returns>
        public static T Create(string name, string assemblyString, object[] args, bool bCache)
        {
            string cacheKey = name;
            T objType = null;
            if (bCache)
            {
                if (objCache.ContainKey(cacheKey))
                {
                    objType = (T)objCache[cacheKey];
                }
                else
                {
                    lock (syncRoot)
                    {
                        if (objCache.ContainKey(cacheKey))
                        {
                            objType = (T)objCache[cacheKey];
                        }
                        else
                        {
                            objType = CreateInstance(cacheKey, assemblyString, args);
                            objCache.Add(cacheKey, objType);
                        }
                    }
                }
            }
            else
            {
                objType = CreateInstance(name, assemblyString, args);
            }

            return objType;
        }

        /// <summary>
        /// 根据路径创建实例对象
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static T CreateFrom(string typeName, string filePath)
        {
            Assembly assemblyObj = Assembly.LoadFrom(filePath);
            if (assemblyObj == null)
            {
                throw new ArgumentNullException("filePath", string.Format("无法加载 FilePath = {0} 的程序集", filePath));
            }

            T obj = (T)assemblyObj.CreateInstance(typeName);

            return obj;
        }
        #endregion //Method
    }
}
