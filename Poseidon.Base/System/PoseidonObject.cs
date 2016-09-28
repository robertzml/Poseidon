using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base
{
    using Poseidon.Base.Model;

    /// <summary>
    /// 自定义属性的动态对象
    /// </summary>
    public class PoseidonObject : BaseEntity
    {
        #region Field
        /// <summary>
        /// 保存对象动态定义的属性值
        /// </summary>
        private Dictionary<string, object> values;
        #endregion //Field

        #region Constructor
        public PoseidonObject()
        {
            this.values = new Dictionary<string, object>();
        }
        #endregion //Constructor

        #region Method
        /// <summary>  
        /// 获取属性值  
        /// </summary>  
        /// <param name="propertyName">属性名称</param>  
        /// <returns></returns>  
        public object GetPropertyValue(string propertyName)
        {
            if (this.values.ContainsKey(propertyName) == true)
            {
                return this.values[propertyName];
            }
            return null;
        }

        /// <summary>  
        /// 设置属性值  
        /// </summary>  
        /// <param name="propertyName">属性名称</param>  
        /// <param name="value">值</param>  
        public void SetPropertyValue(string propertyName, object value)
        {
            if (this.values.ContainsKey(propertyName) == true)
            {
                this.values[propertyName] = value;
            }
            else
            {
                this.values.Add(propertyName, value);
            }
        }

        /// <summary>
        /// 获取属性类型
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        public Type GetPropertyType(string propertyName)
        {
            if (this.values.ContainsKey(propertyName) == true)
            {
                return this.values[propertyName].GetType();
            }
            else
            {
                return typeof(object);
            }
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 获取索引相关属性值
        /// </summary>
        /// <param name="key">属性</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return GetPropertyValue(key);
            }
            set
            {
                SetPropertyValue(key, value);
            }
        }

        public Dictionary<string, object> Values
        {
            get
            {
                return this.values;
            }
        }
        #endregion //Property
    }
}
