﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 组织分组类
    /// </summary>
    public class Group : ObjectEntity
    {
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 上级ID
        /// </summary>
        [Display(Name = "上级ID")]
        public string ParentId { get; set; }

        /// <summary>
        /// 关联模型类型Code
        /// </summary>
        [Display(Name = "关联模型类型")]
        public List<string> ModelTypes { get; set; }

        /// <summary>
        /// 下属组织ID
        /// </summary>
        [Display(Name = "下属组织")]
        public List<string> Organizations { get; set; }
    }
}
