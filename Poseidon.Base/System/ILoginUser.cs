using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.System
{
    /// <summary>
    /// 当前登录用户接口
    /// </summary>
    public interface ILoginUser
    {
        #region Property
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "ID")]
        string Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        string UserName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        string Name { get; set; }

        /// <summary>
        /// 是否Root
        /// </summary>
        [Display(Name = "是否Root")]
        bool IsRoot { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Display(Name = "上次登录时间")]
        DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 本次登录时间
        /// </summary>
        [Display(Name = "本次登录时间")]
        DateTime CurrentLoginTime { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [Display(Name = "备注")]
        string Remark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        int Status { get; set; }
        #endregion //Property
    }
}
