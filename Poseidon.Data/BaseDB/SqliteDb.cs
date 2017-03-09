using System;
using System.Collections.Generic;
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
    internal class SqliteDb : IDisposable
    {
        #region Field
        /// <summary>
        /// 数据源
        /// </summary>
        private string datasource = @"config.db";

        /// <summary>
        /// 是否已连接
        /// </summary>
        private bool isOpen;

        /// <summary>
        /// 是否清理
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 数据库连接
        /// </summary>
        private SQLiteConnection connection;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// Sqlite数据库访问类
        /// </summary>
        public SqliteDb()
        {
            init("");
        }

        /// <summary>
        /// Sqlite数据库访问类
        /// </summary>
        /// <param name="dataSource">数据库文件</param>
        public SqliteDb(string dataSource)
        {
            init(dataSource);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清理所有使用资源
        /// </summary>
        /// <param name="disposing">如果为true则清理托管资源</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // dispose all managed resources.
                if (disposing)
                {
                    this.isOpen = false;
                    connection.Dispose();
                }

                // dispose all unmanaged resources
                this.Close();

                disposed = true;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SqliteDb()
        {
            Dispose(false);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="datasource">数据源</param>
        private void init(string datasource)
        {
            if (datasource != "")
                this.datasource = datasource;

            if (!checkDbExist())
                throw new PoseidonException("无法找到配置文件");

            this.connection = new SQLiteConnection("data source = " + this.datasource);
            // this.parameters = new Dictionary<string, object>();
            this.isOpen = false;
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
            if (!isOpen)
                connection.Open();

            this.isOpen = true;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (isOpen)
                connection.Close();

            this.isOpen = false;
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
