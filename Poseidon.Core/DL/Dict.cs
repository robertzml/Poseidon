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
    /// 字典类
    /// </summary>
    public class Dict : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 分组ID
        /// </summary>
        [Display(Name = "分组ID")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 字典项
        /// </summary>
        [Display(Name = "字典项")]
        public List<DictItem> Items { get; set; }
        #endregion //Property
    }

    /// <summary>
    /// 字典项类
    /// </summary>
    public class DictItem : BaseEntity
    {
        #region Property
        /// <summary>
        /// 键
        /// </summary>
        [Display(Name = "键")]
        public int Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Display(Name = "值")]
        public string Value { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }
        #endregion //Property
    }
}
