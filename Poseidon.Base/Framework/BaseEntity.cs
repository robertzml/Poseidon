using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 基础对象类
    /// </summary>
    public abstract class BaseEntity : IBaseEntity<string>
    {
        #region Property
        /// <summary>
        /// ID
        /// </summary>
        public virtual string Id { get; set; }
        #endregion //Property
    }
}
