using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 服务访问类前缀
    /// </summary>
    public enum CallerType
    {
        /// <summary>
        /// Winform方式
        /// </summary>
        [Display(Name = "Winform方式")]
        Win = 1,

        /// <summary>
        /// WebAPI方式
        /// </summary>
        [Display(Name = "WebAPI方式")]
        WebApi = 2,

        /// <summary>
        /// WCF方式
        /// </summary>
        [Display(Name = "WCF方式")]
        Wcf = 3,
    }
}
