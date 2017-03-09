using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDAL
{
    using Poseidon.Base.System;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// Sqlite数据访问类
    /// </summary>
    internal class BaseDALSqlite
    {
        #region Field
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private SqliteDb db;

        /// <summary>
        /// 参数
        /// </summary>
        private List<SQLiteParameter> parameters;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// Sqlite数据访问类
        /// </summary>
        public BaseDALSqlite()
        {
            db = new SqliteDb();
            this.parameters = new List<SQLiteParameter>();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(string key, object value, DbType type)
        {
            parameters.Add(new SQLiteParameter
            {
                ParameterName = key,
                Value = value,
                DbType = type
            });
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void ExecuteNonQuery(string sql)
        {
            this.db.Open();
            try
            {
                using (SQLiteTransaction transaction = this.db.Connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(this.db.Connection))
                    {
                        command.CommandText = sql;
                        foreach (var para in this.parameters)
                        {
                            command.Parameters.Add(para);
                        }

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            catch (SQLiteException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.db.Close();
                this.parameters.Clear();
            }
        }

        /// <summary>
        /// 执行SQL语句并返回所有结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            this.db.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.db.Connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    command.CommandText = sql;
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }

                    adapter.Fill(dt);
                }
            }
            catch (SQLiteException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.db.Close();
                this.parameters.Clear();
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL语句并返回第一行
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataRow</returns>
        public DataRow ExecuteRow(string sql)
        {
            DataRow row;
            this.db.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.db.Connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    command.CommandText = sql;
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                        row = null;
                    else
                        row = dt.Rows[0];
                }
            }
            catch (SQLiteException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.db.Close();
                this.parameters.Clear();
            }

            return row;
        }

        /// <summary>
        /// 执行SQL语句并返回结果第一行的第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回值</returns>
        public Object ExecuteScalar(string sql)
        {
            Object obj;
            this.db.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.db.Connection))
                {
                    command.CommandText = sql;
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }
                    obj = command.ExecuteScalar();
                }
            }
            catch (SQLiteException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.db.Close();
                this.parameters.Clear();
            }

            return obj;
        }

        /// <summary>
        /// 执行SQL语句并返回Reader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回值</returns>
        public SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteDataReader reader;
            this.db.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(this.db.Connection))
                {
                    command.CommandText = sql;
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }
                    reader = command.ExecuteReader();
                }
            }
            catch (SQLiteException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.db.Close();
                this.parameters.Clear();
            }

            return reader;
        }
        #endregion //Method
    }
}
