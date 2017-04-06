using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 数据访问类前缀
    /// </summary>
    public enum DataBaseType
    {
        /// <summary>
        /// SqlServer数据库
        /// </summary>
        [Display(Name = "SqlServer数据库")]
        SqlServer = 1,

        /// <summary>
        /// MongoDB数据库
        /// </summary>
        [Display(Name = "MongoDB数据库")]
        MongoDB = 2,

        /// <summary>
        /// MySql数据库
        /// </summary>
        [Display(Name = "MySql数据库")]
        MySql = 3,

        /// <summary>
        /// Sqlite数据库
        /// </summary>
        [Display(Name = "Sqlite数据库")]
        Sqlite = 4
    }
}
