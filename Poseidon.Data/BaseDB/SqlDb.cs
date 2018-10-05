using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Poseidon.Data.BaseDB
{
    using Poseidon.Base.System;

    /// <summary>
    /// SQL Server 数据库访问类
    /// </summary>
    public class SqlDb : AbstractDB
    {
        #region Field
        /// <summary>
        /// SQL Server连接
        /// </summary>
        private SqlConnection connection;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// SQL Server数据库访问类
        /// </summary>
        public SqlDb()
        {
            string connectionString = GetConnectionString();
            this.connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// SQL Server数据库访问类
        /// </summary>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        public SqlDb(ConnectionSource source, string key)
        {
            string cs = LoadDbConfig(source, key);
            this.connection = new SqlConnection(cs);
        }

        /// <summary>
        /// SQL Server数据库访问类
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        public SqlDb(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        protected override string GetConnectionString()
        {
            return "server=localhost;database=test;port=1433;user=root;password=root;";
        }
        #endregion //Function

        #region Method
        public SqlConnection GetConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
            var conn = new SqlConnection(connectionString);
            return conn;
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if (connection.State == ConnectionState.Open)
                return;
            connection.Open();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (connection.State == ConnectionState.Closed)
                return;
            connection.Close();
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        public void ExecuteNonQuery(string sql, List<SqlParameter> parameters = null)
        {
            this.Open();

            using (SqlTransaction transaction = this.connection.BeginTransaction())
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(sql, this.connection, transaction))
                    {
                        if (parameters != null)
                        {
                            foreach (var para in parameters)
                            {
                                command.Parameters.Add(para);
                            }
                        }

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    throw new PoseidonException(e.Message);
                }
                finally
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 执行SQL语句并返回所有结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteQuery(string sql, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();
            this.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, this.connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    if (parameters != null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }

                    adapter.Fill(dt);
                }
            }
            catch (SqlException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.Close();
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL语句并返回第一行
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回DataRow</returns>
        public DataRow ExecuteRow(string sql, List<SqlParameter> parameters = null)
        {
            DataRow row;
            this.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, this.connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    if (parameters != null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                        row = null;
                    else
                        row = dt.Rows[0];
                }
            }
            catch (SqlException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.Close();
            }

            return row;
        }

        /// <summary>
        /// 执行SQL语句并返回结果第一行的第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回值</returns>
        public Object ExecuteScalar(string sql, List<SqlParameter> parameters = null)
        {
            Object obj;
            this.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, this.connection))
                {
                    if (parameters != null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    obj = command.ExecuteScalar();
                }
            }
            catch (SqlException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                this.Close();
            }

            return obj;
        }

        /// <summary>
        /// 执行SQL语句并返回Reader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回值</returns>
        public SqlDataReader ExecuteReader(string sql, List<SqlParameter> parameters = null)
        {
            SqlDataReader reader;
            this.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, this.connection))
                {
                    if (parameters != null)
                    {
                        foreach (var para in parameters)
                        {
                            command.Parameters.Add(para);
                        }
                    }
                    reader = command.ExecuteReader();
                }
            }
            catch (SqlException e)
            {
                throw new PoseidonException(e.Message);
            }
            finally
            {
                //this.db.Close();
            }

            return reader;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据库连接
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
        #endregion //Property
    }
}
