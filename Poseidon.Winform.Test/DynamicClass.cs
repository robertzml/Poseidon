using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Winform.Test
{
    public class DynamicClass : DynamicObject, ICustomTypeDescriptor
    {
        //保存对象动态定义的属性值  
        private Dictionary<string, object> _values;
        public DynamicClass()
        {
            _values = new Dictionary<string, object>();
        }

        /// <summary>  
        /// 获取属性值  
        /// </summary>  
        /// <param name="propertyName"></param>  
        /// <returns></returns>  
        public object GetPropertyValue(string propertyName)
        {
            if (_values.ContainsKey(propertyName) == true)
            {
                return _values[propertyName];
            }
            return null;
        }

        /// <summary>  
        /// 设置属性值  
        /// </summary>  
        /// <param name="propertyName"></param>  
        /// <param name="value"></param>  
        public void SetPropertyValue(string propertyName, object value)
        {
            if (_values.ContainsKey(propertyName) == true)
            {
                _values[propertyName] = value;
            }
            else
            {
                _values.Add(propertyName, value);
            }
        }

        /// <summary>  
        /// 实现动态对象属性成员访问的方法，得到返回指定属性的值  
        /// </summary>  
        /// <param name="binder"></param>  
        /// <param name="result"></param>  
        /// <returns></returns>  
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetPropertyValue(binder.Name);
            return result == null ? false : true;
        }

        /// <summary>  
        /// 实现动态对象属性值设置的方法。  
        /// </summary>  
        /// <param name="binder"></param>  
        /// <param name="value"></param>  
        /// <returns></returns>  
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            SetPropertyValue(binder.Name, value);
            return true;
        }

        /// <summary>  
        /// 动态对象动态方法调用时执行的实际代码  
        /// </summary>  
        /// <param name="binder"></param>  
        /// <param name="args"></param>  
        /// <param name="result"></param>  
        /// <returns></returns>  
        //public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        //{
        //    var theDelegateObj = GetPropertyValue(binder.Name) as DelegateObj;
        //    if (theDelegateObj == null || theDelegateObj.CallMethod == null)
        //    {
        //        result = null;
        //        return false;
        //    }
        //    result = theDelegateObj.CallMethod(this, args);
        //    return true;
        //}
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            return base.TryInvoke(binder, args, out result);
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            //var attributes = new Attribute[0];
            //var properties = _values
            //    .Select(pair => new DynamicPropertyDescriptor(this,
            //        pair.Key, pair.Value.GetType(), attributes));
            //return new PropertyDescriptorCollection(properties.ToArray());            
            return TypeDescriptor.GetProperties(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = _values
                .Select(pair => new DynamicPropertyDescriptor(this,
                    pair.Key, pair.Value.GetType(), attributes));
            return new PropertyDescriptorCollection(properties.ToArray());
            //int count = this._values.Count;
            //PropertyDescriptor[] pds = new PropertyDescriptor[count];
            //int index = 0;
            //foreach (var item in this._values)
            //{
            //    pds[index] = new DynamicPropertyDescriptor(item, attributes);
            //    index++;
            //}
            //return new PropertyDescriptorCollection(pds);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }


        class DynamicPropertyDescriptor : PropertyDescriptor
        {
            private readonly DynamicClass businessObject;
            private readonly Type propertyType;

            public DynamicPropertyDescriptor(DynamicClass businessObject,
                string propertyName, Type propertyType, Attribute[] propertyAttributes)
                : base(propertyName, propertyAttributes)
            {
                this.businessObject = businessObject;
                this.propertyType = propertyType;
            }

            public override bool CanResetValue(object component)
            {
                return true;
            }

            public override object GetValue(object component)
            {
                return businessObject._values[Name];
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
                businessObject._values[Name] = value;
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }

            public override Type ComponentType
            {
                get { return typeof(DynamicClass); }
            }

            public override bool IsReadOnly
            {
                get { return false; }
            }

            public override Type PropertyType
            {
                get { return propertyType; }
            }
        }
    }
}
