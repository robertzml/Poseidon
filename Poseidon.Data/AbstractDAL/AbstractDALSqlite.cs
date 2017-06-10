using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Poseidon.Data
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Base.Utility;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// Sqlite抽象数据访问类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractDALSqlite<T> : IBaseDAL<T> where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// Sqlite数据访问接口
        /// </summary>
        private SqliteDb sqlite;

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
        public AbstractDALSqlite()
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
            this.sqlite = new SqliteDb(source, key);
        }

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
        public virtual T FindById(string id)
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
        public virtual T FindOneByField<Tvalue>(string field, Tvalue value)
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

        public virtual IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
        {
            throw new NotImplementedException();
        }


        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0};", this.tableName);
            var obj = this.sqlite.ExecuteScalar(sql);
            return Convert.ToInt64(obj);
        }

        /// <summary>
        /// 根据条件查找记录数量
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual long Count<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE [{1}] = {2}{3};", this.tableName, field, parameterPrefix, field);
            this.sqlite.AddParameter(field, value, PoseidonUtil.TypeToDbType(value.GetType()));

            var obj = this.sqlite.ExecuteScalar(sql);
            return Convert.ToInt64(obj);
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <return></return>
        public virtual T Create(T entity)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return default(T);

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

            return entity;
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="entity">指定的对象</param>
        /// <param name="generateKey">是否自动生成主键</param>
        /// <returns></returns>
        public T Create(T entity, bool generateKey)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return default(T);

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

            return entity;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        /// <remarks>采用主键Id进行限定</remarks>
        public virtual bool Update(T entity)
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

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        /// <remarks>采用主键ID限定</remarks>
        public virtual bool Delete(T entity)
        {
            string condition = string.Format("[id] = {0}id", this.parameterPrefix);
            string sql = string.Format("DELETE FROM {0} WHERE {1} ", this.tableName, condition);

            this.sqlite.AddParameter("id", entity.Id, PoseidonUtil.TypeToDbType(entity.Id.GetType()));
            this.sqlite.ExecuteNonQuery(sql);

            return true;
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual bool DeleteMany<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual void MarkDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void MarkDelete(string id)
        {
            throw new NotImplementedException();
        }

        #endregion //Method
    }
}
