using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Base.System
{
    /// <summary>
    /// 登录用户
    /// </summary>
    public class LoginUser
    {
        #region Property
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "ID")]
        public string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 是否Root
        /// </summary>
        [Display(Name = "是否Root")]
        public bool IsRoot { get; set; }

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

        /// <summary>
        /// 备注 
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }
        #endregion //Property
    }
}
