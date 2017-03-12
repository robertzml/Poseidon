using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDB
{
    using MySql.Data.MySqlClient;
    using Poseidon.Base.System;

    /// <summary>
    /// MySQL数据库访问类
    /// </summary>
    internal class MySqlDb : AbstractDB
    {
        #region Field
        /// <summary>
        /// MySQL连接
        /// </summary>
        private MySqlConnection connection;

        /// <summary>
        /// 参数
        /// </summary>
        private List<MySqlParameter> parameters = new List<MySqlParameter>();
        #endregion //Field

        #region Constructor
        /// <summary>
        /// MySQL数据库访问类
        /// </summary>
        public MySqlDb()
        {
            string connectionString = GetConnectionString();
            this.connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// MySQL数据库访问类
        /// </summary>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        public MySqlDb(ConnectionSource source, string key)
        {
            string cs = LoadDbConfig(source, key);
            this.connection = new MySqlConnection(cs);
        }

        /// <summary>
        /// MySQL数据库访问类
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public MySqlDb(string connectionString)
        {
            this.connection = new MySqlConnection(connectionString);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        protected override string GetConnectionString()
        {
            return "server = 192.168.0.111; user = hc; database = test_zml; port = 3306; password = webDev; ";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return;
            connection.Open();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            connection.Close();
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
            this.Open();
            try
            {
                using (MySqlTransaction transaction = this.connection.BeginTransaction())
                {
                    using (MySqlCommand command = new MySqlCommand(sql, this.connection))
                    {
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
                this.Close();
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
            this.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, this.connection))
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
                this.Close();
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
            this.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, this.connection))
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
                this.Close();
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
            this.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, this.connection))
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
                this.Close();
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
            this.Open();
            try
            {
                using (MySqlCommand command = new MySqlCommand(sql, this.connection))
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

        #region Property
        /// <summary>
        /// 数据库连接
        /// </summary>
        public MySqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
        #endregion //Property
    }
}
