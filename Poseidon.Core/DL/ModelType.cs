﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DL
{
    using Poseidon.Base.Framework;

    /// <summary>
    /// 模型类型类
    /// </summary>
    public class ModelType : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 代码
        /// </summary>
        [Display(Name = "代码")]
        public string Code { get; set; }

        /// <summary>
        /// 类型 1:组织模型 2:建筑模型
        /// </summary>
        [Display(Name = "类型")]
        public int Type { get; set; }
        #endregion //Property
    }
}
