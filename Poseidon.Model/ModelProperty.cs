using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Model
{
    /// <summary>
    /// 自定义模型属性类
    /// </summary>
    public class ModelProperty
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 属性类型
        /// </summary>
        public ModelPropertyType Type { get; set; }

        /// <summary>
        /// 属性说明
        /// </summary>
        public string Remark { get; set; }
    }
}
