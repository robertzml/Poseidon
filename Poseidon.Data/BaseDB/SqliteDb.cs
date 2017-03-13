using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Data.BaseDB
{
    using Poseidon.Base.System;

    /// <summary>
    /// Sqlite数据库访问类
    /// </summary>
    internal class SqliteDb : AbstractDB
    {
        #region Field
        /// <summary>
        /// 数据源
        /// </summary>
        private string datasource = @"config.db";

        /// <summary>
        /// 是否清理
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 数据库连接
        /// </summary>
        private SQLiteConnection connection;

        /// <summary>
        /// 参数
        /// </summary>
        private List<SQLiteParameter> parameters = new List<SQLiteParameter>();
        #endregion //Field

        #region Constructor
        /// <summary>
        /// Sqlite数据库访问类
        /// </summary>
        public SqliteDb()
        {
            string connectionString = GetConnectionString();
            this.connection = new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// Sqlite数据库访问类
        /// </summary>
        /// <param name="source">读取来源</param>
        /// <param name="key">读取键</param>
        public SqliteDb(ConnectionSource source, string key)
        {
            string cs = LoadDbConfig(source, key);
            this.connection = new SQLiteConnection(cs);
        }

        /// <summary>
        /// Sqlite数据库访问类
        /// </summary>
        /// <param name="dataSource">数据库文件</param>
        public SqliteDb(string dataSource)
        {
            this.connection = new SQLiteConnection("data source = " + datasource);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        protected override string GetConnectionString()
        {
            if (!checkDbExist())
                throw new PoseidonException("无法找到配置文件");
            return "data source = " + this.datasource;
        }

        /// <summary>
        /// 检查数据库是否存在
        /// </summary>
        /// <returns></returns>
        private bool checkDbExist()
        {
            if (System.IO.File.Exists(datasource))
                return true;
            else
                return false;
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
            if (this.connection.State == ConnectionState.Closed)
                return;

            connection.Close();
        }

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
            this.Open();
            try
            {
                using (SQLiteTransaction transaction = this.connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(sql, this.connection))
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
            catch (SQLiteException e)
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
                using (SQLiteCommand command = new SQLiteCommand(sql, this.connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
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
                using (SQLiteCommand command = new SQLiteCommand(sql, this.connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
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
                using (SQLiteCommand command = new SQLiteCommand(sql, this.connection))
                {
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
        public SQLiteDataReader ExecuteReader(string sql)
        {
            SQLiteDataReader reader;
            this.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, this.connection))
                {
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
        public SQLiteConnection Connection
        {
            get
            {
                return this.connection;
            }
        }
        #endregion //Property
    }
}
