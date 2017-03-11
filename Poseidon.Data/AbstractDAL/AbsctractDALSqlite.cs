﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Poseidon.Data
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.Utility;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// Sqlite抽象数据访问类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbsctractDALSqlite<T> : IBaseDAL<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// Sqlite数据访问接口
        /// </summary>
        private BaseDALSqlite sqlite;

        /// <summary>
        /// 关联数据表名称
        /// </summary>
        protected string tableName;

        /// <summary>
        /// 参数占位符
        /// </summary>
        private string parameterPrefix = "@";
        #endregion //Field

        #region Constructor
        public AbsctractDALSqlite()
        {
            this.sqlite = new BaseDALSqlite();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// Reader转实体对象
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns></returns>
        protected abstract T ReaderToEntity(SQLiteDataReader reader);

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected abstract Hashtable EntityToHash(T entity);
        #endregion //Function

        #region Method
        public T FindById(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE [{1}] = {2}{3};", this.tableName, field, parameterPrefix, field);
            this.sqlite.AddParameter(field, value, PoseidonUtil.TypeToDbType(value.GetType()));

            var reader = this.sqlite.ExecuteReader(sql);
            if (reader.Read())
            {
                T entity = ReaderToEntity(reader);
                reader.Close();
                return entity;
            }
            else
            {
                reader.Close();
                return null;
            }
        }


        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public long Count<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE [{1}] = {2}{3};", this.tableName, field, parameterPrefix, field);
            this.sqlite.AddParameter(field, value, PoseidonUtil.TypeToDbType(value.GetType()));

            var obj = this.sqlite.ExecuteScalar(sql);
            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
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

                this.sqlite.AddParameter(field, val, PoseidonUtil.TypeToDbType(val.GetType()));
            }

            this.sqlite.ExecuteNonQuery(sql);

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
                if (field == "Id")
                    continue;
                setValue += string.Format("[{0}] = {1}{2},", field, parameterPrefix, field);
            }

            setValue = setValue.Substring(0, setValue.Length - 1);
            string sql = string.Format("UPDATE {0} SET {1} WHERE [id] = {2}id", this.tableName, setValue, parameterPrefix);

            foreach (string field in hash.Keys)
            {
                object val = hash[field];
                val = val ?? DBNull.Value;

                this.sqlite.AddParameter(field, val, PoseidonUtil.TypeToDbType(val.GetType()));
            }

            this.sqlite.ExecuteNonQuery(sql);
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
