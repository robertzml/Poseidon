using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base
{
    /// <summary>
    /// PoseidonObject 属性描述器
    /// </summary>
    public class PoseidonPropertyDescriptor : PropertyDescriptor
    {
        #region Field
        /// <summary>
        /// PoseidonObject 实例
        /// </summary>
        private readonly PoseidonObject poseidonObject;

        /// <summary>
        /// 属性类型
        /// </summary>
        private readonly Type propertyType;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// PoseidonObject 属性描述器
        /// </summary>
        /// <param name="name">属性描述器</param>
        public PoseidonPropertyDescriptor(string name)
            : base(name, null)
        { }

        /// <summary>
        /// PoseidonObject 属性描述器
        /// </summary>
        /// <param name="poseidonObject">属性描述器</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyType">属性类型</param>
        /// <param name="propertyAttributes">属性特性</param>
        public PoseidonPropertyDescriptor(PoseidonObject poseidonObject, string propertyName, Type propertyType, Attribute[] propertyAttributes)
                : base(propertyName, propertyAttributes)
        {
            this.poseidonObject = poseidonObject;
            this.propertyType = propertyType;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="component">组件对象</param>
        /// <returns></returns>
        public override object GetValue(object component)
        {
            return ((PoseidonObject)component)[Name];
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="component">组件对象</param>
        /// <param name="value"></param>
        public override void SetValue(object component, object value)
        {
            ((PoseidonObject)component)[Name] = value;
        }

        /// <summary>
        /// 能否重置值
        /// </summary>
        /// <param name="component">组件对象</param>
        /// <returns></returns>
        public override bool CanResetValue(object component)
        {
            return true;
        }

        /// <summary>
        /// 重置值
        /// </summary>
        /// <param name="component">组件对象</param>
        public override void ResetValue(object component)
        {
            ((PoseidonObject)component)[Name] = null;
        }

        /// <summary>
        /// 是否序列化值
        /// </summary>
        /// <param name="component">组件对象</param>
        /// <returns></returns>
        public override bool ShouldSerializeValue(object component)
        {
            return ((PoseidonObject)component)[Name] != null;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 组件类型
        /// </summary>
        public override Type ComponentType
        {
            get
            {
                return typeof(PoseidonObject);
            }
        }

        /// <summary>
        /// 是否只读
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 属性类型
        /// </summary>
        public override Type PropertyType
        {
            get
            {
                if (propertyType == null)
                    return typeof(object);
                else
                    return propertyType;
            }
        }
        #endregion //Property
    }
}
