using System;
using System.Collections;
using System.Collections.Generic;
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
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 按默认方式初始化
        /// </summary>
        /// <param name="tableName">对应数据表名称</param>
        protected virtual void Init(string tableName)
        {
            Init(tableName, ConnectionSource.Default, "");
        }

        /// <summary>
        /// 按设置进行初始化
        /// </summary>
        /// <param name="tableName">对应数据表名称</param>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        protected virtual void Init(string tableName, ConnectionSource source, string key)
        {
            this.tableName = tableName;
            this.mysql = new MySqlDb(source, key);
        }

        /// <summary>
        /// Reader转实体对象
        /// </summary>
        /// <param name="reader">Reader</param>
        /// <returns></returns>
        protected abstract T ReaderToEntity(MySqlDataReader reader);

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected abstract Hashtable EntityToHash(T entity);
        #endregion //Function

        #region Method
        public T FindById(Tkey id)
        {
            throw new NotImplementedException();
        }

        public T FindById(object id)
        {
            throw new NotImplementedException();
        }

        public T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE [{1}] = {2}{3};", this.tableName, field, parameterPrefix, field);
            this.mysql.AddParameter(field, value);

            var reader = this.mysql.ExecuteReader(sql);
            if (reader.Read())
            {
                T entity = ReaderToEntity(reader);
                reader.Close();
                return entity;
            }
            else
            {
                reader.Close();
                return default(T);
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

        public long Count<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

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

        public bool Update(T entity)
        {
            throw new NotImplementedException();
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
