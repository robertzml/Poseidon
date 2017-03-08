using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.Utility
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.Utility;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 字典工具类
    /// </summary>
    public static class DictUtility
    {
        /// <summary>
        /// 获取字典值
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="field">属性字段</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetDictValue(BaseEntity entity, string field, int key)
        {
            Type t = entity.GetType();
            var propertyInfo = t.GetProperty(field);
            var attr = Attribute.GetCustomAttribute(propertyInfo, typeof(DictAttribute)) as DictAttribute;

            return BusinessFactory<DictBusiness>.Instance.FindValue(attr.DictCode, key);
        }
    }
}
