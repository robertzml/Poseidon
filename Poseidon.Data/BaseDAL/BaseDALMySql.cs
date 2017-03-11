using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDAL
{
    using MySql.Data.MySqlClient;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Data.BaseDB;

    /// <summary>
    /// MySQL数据访问类
    /// </summary>
    internal class BaseDALMySql
    {
        #region Field
        /// <summary>
        /// 数据库访问对象
        /// </summary>
        private MySqlDb db;

        /// <summary>
        /// 参数
        /// </summary>
        private List<MySqlParameter> parameters;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// MySQL数据访问类
        /// </summary>
        public BaseDALMySql() : this("")
        {
        }

        /// <summary>
        /// MySQL数据访问类
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public BaseDALMySql(string connectionString)
        {
            this.db = new MySqlDb(connectionString);
            this.parameters = new List<MySqlParameter>();
        }
        #endregion //Constructor

        #region Method
        public void SetDbConfig(ConnectionSource source, string key)
        {
            string cs = "";
            switch (source)
            {
                case ConnectionSource.Default:
                    cs = AppConfig.GetConnectionString();
                    break;
                case ConnectionSource.Config:
                    cs = AppConfig.GetConnectionString(key);
                    break;
                case ConnectionSource.Cache:
                    cs = Cache.Instance[key].ToString();
                    break;
            }

            this.db = new MySqlDb();
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(string name, object value)
        {
            parameters.Add(new MySqlParameter(name, value));
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(string name, object value, MySqlDbType type)
        {
            parameters.Add(new MySqlParameter
            {
                ParameterName = name,
                Value = value,
                MySqlDbType = type
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
                using (MySqlTransaction transaction = this.db.Connection.BeginTransaction())
                {
                    using (MySqlCommand command = new MySqlCommand(sql, this.db.Connection))
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
            catch (MySqlException e)
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
                using (MySqlCommand command = new MySqlCommand(sql, this.db.Connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }

                    adapter.Fill(dt);
                }
            }
            catch (MySqlException e)
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
                using (MySqlCommand command = new MySqlCommand(sql, this.db.Connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
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
            catch (MySqlException e)
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
                using (MySqlCommand command = new MySqlCommand(sql, this.db.Connection))
                {
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }
                    obj = command.ExecuteScalar();
                }
            }
            catch (MySqlException e)
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
        public MySqlDataReader ExecuteReader(string sql)
        {
            MySqlDataReader reader;
            this.db.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, this.db.Connection))
                {
                    foreach (var para in this.parameters)
                    {
                        command.Parameters.Add(para);
                    }
                    reader = command.ExecuteReader();
                }
            }
            catch (MySqlException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                //this.db.Close();
                this.parameters.Clear();
            }

            return reader;
        }
        #endregion //Method
    }
}
