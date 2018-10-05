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
    /// 建筑类
    /// </summary>
    public class Building : ObjectEntity
    {
        #region Property
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
        #endregion //Property
    }
}
