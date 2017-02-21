using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 组织类
    /// </summary>
    public class Organization : ObjectEntity
    {
        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 模型类型
        /// </summary>
        [Display(Name = "模型类型")]
        public string ModelType { get; set; }
    }
}
