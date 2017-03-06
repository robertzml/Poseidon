using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 用户账户类
    /// </summary>
    public class User : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public override string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 拥有角色
        /// </summary>
        [Display(Name = "拥有角色")]
        public List<string> Roles { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Display(Name = "上次登录时间")]
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 本次登录时间
        /// </summary>
        [Display(Name = "本次登录时间")]
        public DateTime CurrentLoginTime { get; set; }
        #endregion //Property
    }
}
