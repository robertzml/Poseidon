using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Common;

    /// <summary>
    /// 全局操作类
    /// </summary>
    public sealed class GlobalAction
    {
        #region Field
        /// <summary>
        /// 实例
        /// </summary>
        private static volatile GlobalAction _instance;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Constructor
        private GlobalAction()
        {
           
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 设置登录用户
        /// </summary>
        /// <param name="user">用户信息</param>
        public LoginUser ConvertToLoginUser(User user)
        {
            LoginUser lu = new LoginUser
            {
                Id = user.Id,
                UserName = user.UserName,
                IsRoot = true,
                Name = user.Name,
                LastLoginTime = user.LastLoginTime,
                CurrentLoginTime = user.CurrentLoginTime,
                Remark = user.Remark,
                Status = user.Status
            };

            return lu;
        }

        /// <summary>
        /// 获取插件路径
        /// </summary>
        /// <returns></returns>
        public string GetPluginPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + AppConfig.GetAppSetting("PluginPath") + "\\";
            return path;                
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 单件实例
        /// </summary>
        public static GlobalAction Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new GlobalAction();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion //Property
    }
}
