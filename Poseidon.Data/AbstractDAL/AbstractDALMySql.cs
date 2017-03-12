﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using MySql.Data.MySqlClient;
    using Poseidon.Base.Framework;
    using Poseidon.Common;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// MySQL抽象数据访问类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractDALMySql<T, Tkey> : IBaseDAL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        #region Field
        /// <summary>
        /// MySQL数据访问接口
        /// </summary>
        private MySqlDb mysql;

        /// <summary>
        /// 关联数据表名称
        /// </summary>
        private string tableName;

        /// <summary>
        /// 主键字段
        /// </summary>
        private string primaryKey;

        /// <summary>
        /// 参数占位符
        /// </summary>
        private string parameterPrefix = "@";
        #endregion //Field

        #region Constructor
        /// <summary>
        /// MySQL抽象数据访问类
        /// </summary>
        public AbstractDALMySql()
        {
        }

        /// <summary>
        /// MySQL抽象数据访问类
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="primaryKey">主键字段</param>
        public AbstractDALMySql(string tableName, string primaryKey)
        {
            this.tableName = tableName;
            this.primaryKey = primaryKey;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 按默认方式初始化
        /// </summary>
        protected virtual void Init()
        {
            Init(ConnectionSource.Default, "");
        }

        /// <summary>
        /// 按设置进行初始化
        /// </summary>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        protected virtual void Init(ConnectionSource source, string key)
        {
            this.mysql = new MySqlDb(source, key);
        }

        /// <summary>
        /// DataReader转实体对象
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        protected abstract T DataReaderToEntity(MySqlDataReader reader);

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected abstract T DataRowToEntity(DataRow row);

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected abstract Hashtable EntityToHash(T entity);
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public T FindById(Tkey id)
        {
            string sql = string.Format("Select * From {0} Where ({1} = {2}Id)", this.tableName, this.primaryKey, parameterPrefix);
            this.mysql.AddParameter("Id", id);

            var reader = this.mysql.ExecuteReader(sql);
            if (reader.Read())
            {
                T entity = DataReaderToEntity(reader);
                reader.Close();
                return entity;
            }
            else
            {
                reader.Close();
                return default(T);
            }
        }

        /// <summary>
        /// 根据条件查找单条记录
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE [{1}] = {2}{3};", this.tableName, field, parameterPrefix, field);
            this.mysql.AddParameter(field, value);

            var row = this.mysql.ExecuteRow(sql);
            if (row == null)
                return default(T);

            T entity = DataRowToEntity(row);
            return entity;
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> FindAll()
        {
            string sql = string.Format("SELECT * FROM {0};", this.tableName);

            var dt = this.mysql.ExecuteQuery(sql);

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = DataRowToEntity(row);
                data.Add(entity);
            }

            return data;
        }

        public IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void Create(T entity)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return;

            string fields = "";
            string vals = "";
            foreach (string field in hash.Keys)
            {
                fields += string.Format("[{0}],", field);
                vals += string.Format("{0}{1},", parameterPrefix, field);
            }

            fields = fields.Trim(',');
            vals = vals.Trim(',');
            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", this.tableName, fields, vals);

            foreach (string field in hash.Keys)
            {
                object val = hash[field];
                val = val ?? DBNull.Value;

                this.mysql.AddParameter(field, val);
            }

            this.mysql.ExecuteNonQuery(sql);

            return;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        /// <remarks>采用主键Id进行限定</remarks>
        public bool Update(T entity)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return false;

            string setValue = "";
            foreach (string field in hash.Keys)
            {
                if (field == this.primaryKey)
                    continue;
                setValue += string.Format("[{0}] = {1}{2},", field, parameterPrefix, field);
            }

            setValue = setValue.Substring(0, setValue.Length - 1);
            string sql = string.Format("UPDATE {0} SET {1} WHERE {2} = {3}{2}", this.tableName, setValue, this.primaryKey, parameterPrefix);

            foreach (string field in hash.Keys)
            {
                object val = hash[field];
                val = val ?? DBNull.Value;

                this.mysql.AddParameter(field, val);
            }

            this.mysql.ExecuteNonQuery(sql);
            return true;
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMany<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
