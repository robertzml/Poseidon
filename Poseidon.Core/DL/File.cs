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
    /// 文件类
    /// </summary>
    public class File : ObjectEntity
    {
        #region Property
        /// <summary>
        /// 模型类型
        /// </summary>
        [Display(Name = "模型类型")]
        public string ModelType { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        [Display(Name = "文件名")]
        public string FileName { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        [Display(Name = "扩展名")]
        public string Extension { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Display(Name = "文件类型")]
        public string ContentType { get; set; }

        /// <summary>
        /// 文件大小(字节)
        /// </summary>
        [Display(Name = "文件大小")]
        public long Size { get; set; }

        /// <summary>
        /// 创建标注
        /// </summary>
        [Display(Name = "创建标注")]
        public UpdateStamp CreateBy { get; set; }

        /// <summary>
        /// 挂载点
        /// </summary>
        [Display(Name = "挂载点")]
        public string Mount { get; set; }

        /// <summary>
        /// 类型 1:普通文件 2:目录文件 3:链接文件 4:特殊文件
        /// </summary>
        [Display(Name = "类型")]
        public int Type { get; set; }

        /// <summary>
        /// 数据集代码
        /// </summary>
        [Display(Name = "数据集代码")]
        public string DatasetCode { get; set; }
        #endregion //Property
    }
}
