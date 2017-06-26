using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Common
{
    /// <summary>
    /// 缓存项类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class CacheItem<T> : ISerializable
    {
        #region Field
        /// <summary>
        /// 键
        /// </summary>
        private string key;

        /// <summary>
        /// 值
        /// </summary>
        private T value;

        /// <summary>
        /// 值类型
        /// </summary>
        private Type valueType;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 初始化缓存项
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public CacheItem(string key, T value)
        {
            this.key = key;
            this.value = value;
            this.valueType = value.GetType();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 序列化方法
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(key), key);
            info.AddValue(nameof(value), value);
            info.AddValue(nameof(valueType), valueType);
        }
        #endregion //Method
    }
}
