using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Base.System
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        #region System
        /// <summary>
        /// 成功
        /// </summary>
        [Display(Name = "成功")]
        Success = 0,

        /// <summary>
        /// 错误
        /// </summary>
        [Display(Name = "错误")]
        Error = 1,

        /// <summary>
        /// 异常
        /// </summary>
        [Display(Name = "异常")]
        Exception = 2,

        /// <summary>
        /// 未实现程序
        /// </summary>
        [Display(Name = "未实现程序")]
        NotImplement = 3,

        /// <summary>
        /// 对象无法创建
        /// </summary>
        [Display(Name = "对象无法创建")]
        ObjectNotCreate = 4,

        /// <summary>
        /// 对象已删除
        /// </summary>
        [Display(Name = "对象已删除")]
        ObjectDeleted = 5,

        /// <summary>
        /// 对象未找到
        /// </summary>
        [Display(Name = "对象未找到")]
        ObjectNotFound = 6,

        /// <summary>
        /// 数据库写入失败
        /// </summary>
        [Display(Name = "数据库写入失败")]
        DatabaseWriteError = 7,

        /// <summary>
        /// 权限不够
        /// </summary>
        [Display(Name = "权限不够")]
        NoPrivilege = 8,

        /// <summary>
        /// HTTP访问错误
        /// </summary>
        [Display(Name = "HTTP访问错误")]
        HTTPError = 9,

        /// <summary>
        /// 未选择记录
        /// </summary>
        [Display(Name = "未选择记录")]
        EmptySelect = 12,

        /// <summary>
        /// 对象为空
        /// </summary>
        [Display(Name = "对象为空")]
        ObjectIsEmpty = 13,
        #endregion //System

        #region Config
        /// <summary>
        /// 未找到配置文件
        /// </summary>
        [Display(Name = "数据库连接未找到")]
        ConfigFileNotFound = 20,

        /// <summary>
        /// 配置文件:ConnectionSource未找到
        /// </summary>
        [Display(Name = "配置文件:ConnectionSource未找到")]
        ConnectionSourceNotFound = 21,

        /// <summary>
        /// 配置文件:DbConnection未找到
        /// </summary>
        [Display(Name = "配置文件:DbConnection未找到")]
        DbConnectionNotFound = 22,

        /// <summary>
        /// 数据库连接未找到
        /// </summary>
        [Display(Name = "数据库连接未找到")]
        DatabaseConnectionNotFound = 23,
        #endregion //Config

        #region Object Check
        /// <summary>
        /// 名称为空
        /// </summary>
        [Display(Name = "名称为空")]
        EmptyName = 30,

        /// <summary>
        /// 名称重复
        /// </summary>
        [Display(Name = "名称重复")]
        DuplicateName = 31,

        /// <summary>
        /// 编号重复
        /// </summary>
        [Display(Name = "编号重复")]
        DuplicateNumber = 32,

        /// <summary>
        /// 代码重复
        /// </summary>
        [Display(Name = "代码重复")]
        DuplicateCode = 33,
        #endregion //Object Check
    }
}
