using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.Utility;
    using Poseidon.Common;

    /// <summary>
    /// 全局操作类
    /// </summary>
    public static class GlobalAction
    {
        #region Field
        public static LoginUser CurrentUser = null;
        #endregion //Field

        #region Constructor

        #endregion //Constructor

        #region Method
        /// <summary>
        /// 全局初始化
        /// </summary>
        public static void Initialize()
        {
            //ConfigUtility.SetConnectionString("mongodb://uposeidon:pose.170308!@210.28.16.82:27015/poseidon");

        }

        /// <summary>
        /// 设置登录用户
        /// </summary>
        /// <param name="user">用户信息</param>
        public static LoginUser ConvertToLoginUser(User user)
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
        public static string GetPluginPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + AppConfig.GetAppSetting("PluginPath") + "\\";
            return path;
        }
        #endregion //Method

        #region Property

        #endregion //Property
    }
}
