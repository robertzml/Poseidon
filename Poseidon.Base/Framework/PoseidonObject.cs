using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    /// <summary>
    /// 自定义属性的动态对象类
    /// </summary>
    /// <remarks>
    /// 表示一个对象，是自定义类型的一个具体对象。
    /// 该对象也是动态的，运行时确定对象的属性。
    /// </remarks>
    public class PoseidonObject : BaseEntity
    {
        #region Field
        /// <summary>
        /// 保存对象动态定义的属性值
        /// </summary>
        private Hashtable values;
        #endregion //Field

        #region Constructor
        public PoseidonObject()
        {
            this.values = new Hashtable();
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

        /// <summary>
        /// 获取所有字段名
        /// </summary>
        public List<string> Fields
        {
            get
            {
                List<string> fields = new List<string>();
                var keys = this.values.Keys.GetEnumerator();
                while(keys.MoveNext())
                {
                    fields.Add(keys.Current.ToString());
                }

                return fields;
            }
        }

        /// <summary>
        /// 获取所有键值
        /// </summary>
        public Hashtable Table
        {
            get
            {
                return this.values;
            }
        }
        #endregion //Property
    }
}
