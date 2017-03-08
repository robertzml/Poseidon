using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.Utility
{
    /// <summary>
    /// 字典特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DictAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// 字典代码
        /// </summary>
        private string dictCode;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 字典特性
        /// </summary>
        /// <param name="dictCode">字典代码</param>
        public DictAttribute(string dictCode)
        {
            this.dictCode = dictCode;
        }
        #endregion //Constructor

        #region Property
        /// <summary>
        /// 字典代码
        /// </summary>
        public string DictCode
        {
            get
            {
                return this.dictCode;
            }
        }
        #endregion //Property
    }
}
