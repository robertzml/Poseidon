using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Model
{
    using Poseidon.Base.Model;

    /// <summary>
    /// 能源模型基类
    /// </summary>
    public class EnergyModel : BaseEntity
    {
        #region Property
        /// <summary>
        /// 标识
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 继承基类
        /// </summary>
        public string Base { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        #endregion //Property
    }
}
