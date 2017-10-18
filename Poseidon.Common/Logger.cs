﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Common
{
    /// <summary>
    /// 日志记录类
    /// </summary>
    public class Logger
    {
        #region Field
        /// <summary>
        /// 单件实例
        /// </summary>
        private static volatile Logger instance = null;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object lockHelper = new object();

        /// <summary>
        /// 实例锁变量
        /// </summary>
        private static object lockInstance = new object();

        /// <summary>
        /// 写入锁变量
        /// </summary>
        private static object lockWrite = new object();

        /// <summary>
        /// 日志路径
        /// </summary>
        private string folder;

        /// <summary>
        /// 日志级别
        /// 0: 不记录 1:异常 2:错误 3:警告 4:信息 5:调试
        /// </summary>
        private readonly int logLevel = 1;

        /// <summary>
        /// 日志类别名称
        /// </summary>
        private readonly string[] levelName = { "异常", "错误", "警告", "信息", "调试" };
        #endregion //Field

        #region Constructor
        private Logger()
        {
            string level = AppConfig.GetAppSetting("LogLevel");
            this.logLevel = Convert.ToInt32(level);

            this.folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="message">消息</param>
        private void WriteMessage(int level, string message)
        {
            try
            {
                string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

                string time = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
                string title = "[" + levelName[level - 1] + "]";

                string text = time + " " + title + "\t" + message + "\r\n";

                lock (lockWrite)
                {
                    File.AppendAllText(Path.Combine(folder, fileName), text, Encoding.GetEncoding("utf-8"));
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="e">异常</param>
        private void WriteException(string message, Exception e)
        {
            try
            {
                string fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

                string time = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
                string title = "[异常]";                

                string text = string.Format("{0} {1}\r\n\tMessage: {2}\r\n\tSource: {3}\r\n\tTarget: {4}\r\n\tStack: {5}\r\n",
                    time, title, e.Message, e.Source, e.TargetSite.Name, e.StackTrace);

                lock (lockWrite)
                {
                    File.AppendAllText(Path.Combine(folder, fileName), text, Encoding.GetEncoding("utf-8"));
                }
            }
            catch(Exception)
            {

            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message">信息</param>
        public void Debug(string message)
        {
            if (this.logLevel >= 5)
            {
                this.WriteMessage(5, message);
            }
        }

        /// <summary>
        /// 记录消息
        /// </summary>
        /// <param name="message">信息</param>
        public void Info(string message)
        {
            if (this.logLevel >= 4)
            {
                this.WriteMessage(4, message);
            }
        }

        /// <summary>
        /// 记录警告
        /// </summary>
        /// <param name="message">信息</param>
        public void Warning(string message)
        {
            if (this.logLevel >= 3)
            {
                this.WriteMessage(3, message);
            }
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message">信息</param>
        public void Error(string message)
        {
            if (this.logLevel >= 2)
            {
                this.WriteMessage(2, message);
            }
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="message">信息</param>
        /// <param name="e">异常</param>
        public void Exception(string message, Exception e)
        {
            if (this.logLevel >= 1)
            {
                this.WriteException(message, e);
            }
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 单件实例
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
                    {
                        if (instance == null)
                        {
                            instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }
        #endregion //Property
    }
}
