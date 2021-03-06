﻿using System;
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
        /// 缓存
        /// </summary>
        private static Cache objCache = Cache.Instance;

        /// <summary>
        /// 数据类缓存
        /// </summary>
        //private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 数据库前缀转换
        /// </summary>
        /// <param name="prefix">数据库前缀</param>
        /// <returns></returns>
        private static string DBTypeToString(DataBaseType prefix)
        {
            switch (prefix)
            {
                case DataBaseType.SqlServer:
                    return "SQLServer";
                case DataBaseType.MongoDB:
                    return "Mongo";
                case DataBaseType.MySql:
                    return "MySQL";
                case DataBaseType.Sqlite:
                    return "Sqlite";
            }

            return "";
        }

        /// <summary>
        /// 载入相关数据访问程序集
        /// 由缓存DALPrefix确定
        /// </summary>
        /// <returns></returns>
        private static T LoadAssembly()
        {
            string prefix = Cache.Instance["DALPrefix"].ToString();
            prefix = "DAL." + prefix;

            string name = typeof(T).Name;
            string insName = typeof(T).Name.Remove(0, 1); //Remove the first 'I' character

            string fullName = typeof(T).FullName;
            fullName = fullName.Replace("IDAL", prefix).Replace(name, insName); //bind new instance name

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name, false); //reflection create
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

            T o = Reflect<T>.Create(fullName, typeof(T).Assembly.GetName().Name, false); //reflection create
            return o;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 创建业务类的实例，不缓存
        /// </summary>
        /// <param name="prefix">数据访问层前缀</param>
        /// <returns></returns>
        public static T GetInstance(DataBaseType prefix)
        {
            string p = DBTypeToString(prefix);
            T dal = LoadAssembly(p);
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
                            T dal = LoadAssembly();
                            objCache.Add(cacheKey, dal);
                            return dal;
                        }
                    }
                }
            }
        }
        #endregion //Property
    }
}
