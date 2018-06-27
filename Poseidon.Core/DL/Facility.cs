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
    /// 设施类
    /// </summary>
    public class Facility : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 模型类型
        /// </summary>
        [Display(Name = "模型类型")]
        public string ModelType { get; set; }

        /// <summary>
        /// 数据集代码
        /// </summary>
        [Display(Name = "数据集代码")]
        public string DatasetCode { get; set; }
        #endregion //Property
    }
}
