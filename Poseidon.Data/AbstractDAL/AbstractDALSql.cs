using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// SQL Server抽象数据访问类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractDALSql<T, Tkey> : IBaseDAL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        #region Field
        /// <summary>
        /// SQL Server数据访问接口
        /// </summary>
        private SqlDb sqlServer;

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
        protected string parameterPrefix = "@";
        #endregion //Field

        #region Constructor
        /// <summary>
        /// SQL Server抽象数据访问类
        /// </summary>
        public AbstractDALSql()
        {
        }

        /// <summary>
        /// SQL Server抽象数据访问类
        /// </summary>
        /// <param name="tableName">数据表名</param>
        /// <param name="primaryKey">主键字段</param>
        public AbstractDALSql(string tableName, string primaryKey)
        {
            this.tableName = "[" + tableName + "]";
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
            this.sqlServer = new SqlDb(source, key);
        }

        /// <summary>
        /// DataReader转实体对象
        /// </summary>
        /// <param name="reader">DataReader</param>
        /// <returns></returns>
        protected abstract T DataReaderToEntity(SqlDataReader reader);

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
        public virtual T FindById(Tkey id)
        {
            string sql = string.Format("Select * From {0} Where ({1} = {2}{1})", this.tableName, this.primaryKey, parameterPrefix);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = this.primaryKey, Value = id });

            var row = this.sqlServer.ExecuteRow(sql, parameters);
            if (row == null)
                return default(T);
            else
            {
                T entity = DataRowToEntity(row);
                return entity;
            }
        }

        /// <summary>
        /// 根据条件查找单条记录
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual T FindOneByField<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}{3};", this.tableName, field, parameterPrefix, field);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = field, Value = value });

            var row = this.sqlServer.ExecuteRow(sql, parameters);
            if (row == null)
                return default(T);

            T entity = DataRowToEntity(row);
            return entity;
        }

        /// <summary>
        /// 按条件查找单条记录
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public virtual T FindOne(string condition, List<SqlParameter> paras)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1};", this.tableName, condition);

            var row = this.sqlServer.ExecuteRow(sql, paras);

            if (row == null)
                return default(T);

            T entity = DataRowToEntity(row);
            return entity;
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> FindAll()
        {
            string sql = string.Format("SELECT * FROM {0};", this.tableName);

            var dt = this.sqlServer.ExecuteQuery(sql);

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = DataRowToEntity(row);
                data.Add(entity);
            }

            return data;
        }

        public virtual IEnumerable<T> FindByStatus(EntityStatus status)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件查找记录
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        public virtual IEnumerable<T> FindListByField<Tvalue>(string field, Tvalue value)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1} = {2}{1};", this.tableName, field, parameterPrefix);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = field, Value = value });

            var dt = this.sqlServer.ExecuteQuery(sql, parameters);

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = DataRowToEntity(row);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 按ID列表查找记录
        /// </summary>
        /// <param name="values">ID列表</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindListInIds(List<Tkey> values)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查找多条记录
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public virtual IEnumerable<T> FindList(string condition, List<SqlParameter> paras)
        {
            string sql = string.Format("SELECT * FROM {0} WHERE {1};", this.tableName, condition);

            var dt = this.sqlServer.ExecuteQuery(sql, paras);

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T entity = DataRowToEntity(row);
                data.Add(entity);
            }

            return data;
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count()
        {
            string sql = string.Format("SELECT COUNT(*) FROM {0};", this.tableName);
            var obj = this.sqlServer.ExecuteScalar(sql);
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
            string sql = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = {2}{1};", this.tableName, field, parameterPrefix);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = field, Value = value });

            var obj = this.sqlServer.ExecuteScalar(sql, parameters);
            return Convert.ToInt64(obj);
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual T Create(T entity)
        {
            return Create(entity, true);
        }

        /// <summary>
        /// 插入指定对象到数据库中
        /// </summary>
        /// <param name="entity">指定的对象</param>
        /// <param name="generateKey">是否自动生成主键</param>
        /// <returns></returns>
        public virtual T Create(T entity, bool generateKey)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return default(T);

            string fields = "";
            string vals = "";
            foreach (string field in hash.Keys)
            {
                if (generateKey && field == this.primaryKey)
                    continue;
                fields += string.Format("{0},", field);
                vals += string.Format("{0}{1},", parameterPrefix, field);
            }

            fields = fields.Trim(',');
            vals = vals.Trim(',');

            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", this.tableName, fields, vals);
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (string field in hash.Keys)
            {
                object val = hash[field];
                val = val ?? DBNull.Value;

                parameters.Add(new SqlParameter { ParameterName = field, Value = val });
            }

            this.sqlServer.ExecuteNonQuery(sql, parameters);

            return entity;
        }

        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        /// <remarks>采用主键Id进行限定</remarks>
        public virtual (bool success, string errorMessage) Update(T entity)
        {
            var hash = EntityToHash(entity);
            if (hash == null || hash.Count < 1)
                return (false, ErrorCode.ObjectIsEmpty.DisplayName());

            string setValue = "";
            foreach (string field in hash.Keys)
            {
                if (field == this.primaryKey)
                    continue;
                setValue += string.Format("{0} = {1}{2},", field, parameterPrefix, field);
            }

            setValue = setValue.Substring(0, setValue.Length - 1);

            string sql = string.Format("UPDATE {0} SET {1} WHERE {2} = {3}{2}", this.tableName, setValue, this.primaryKey, parameterPrefix);
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (string field in hash.Keys)
            {
                object val = hash[field];
                val = val ?? DBNull.Value;

                parameters.Add(new SqlParameter { ParameterName = field, Value = val });
            }

            this.sqlServer.ExecuteNonQuery(sql, parameters);
            return (true, "");
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">对象实体</param>
        /// <returns></returns>
        public virtual (bool success, string errorMessage) Delete(T entity)
        {
            string condition = string.Format("{0} = {1}{0}", this.primaryKey, this.parameterPrefix);
            string sql = string.Format("DELETE FROM {0} WHERE {1} ", this.tableName, condition);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = primaryKey, Value = entity.Id });

            this.sqlServer.ExecuteNonQuery(sql, parameters);

            return (true, "");
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual (bool success, string errorMessage) Delete(Tkey id)
        {
            string condition = string.Format("{0} = {1}{0}", this.primaryKey, this.parameterPrefix);
            string sql = string.Format("DELETE FROM {0} WHERE {1} ", this.tableName, condition);

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter { ParameterName = primaryKey, Value = id });

            this.sqlServer.ExecuteNonQuery(sql, parameters);

            return (true, "");
        }

        public virtual (bool success, string errorMessage) Delete<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual (bool success, string errorMessage) DeleteMany<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public virtual void MarkDelete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void MarkDelete(Tkey id)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
