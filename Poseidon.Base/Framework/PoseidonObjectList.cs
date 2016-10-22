using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
    using Poseidon.Base.Utility;

    /// <summary>
    /// 自定义属性的动态对象列表类
    /// 表示动态对象的集合
    /// </summary>
    public class PoseidonObjectList : List<PoseidonObject>, ITypedList
    {
        #region Field
        /// <summary>
        /// 列名集合
        /// </summary>
        private List<string> columns;

        /// <summary>
        /// 列类型集合
        /// </summary>
        private List<Type> columnTypes;

        /// <summary>
        /// 列描述集合
        /// </summary>
        private List<string> columnDescription;
        #endregion //Field                

        #region Constructor
        public PoseidonObjectList()
        {
            this.columns = new List<string>();
            this.columnDescription = new List<string>();
            this.columnTypes = new List<Type>();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加列定义
        /// </summary>
        /// <param name="column">列名</param>
        /// <param name="type">列类型</param>
        /// <param name="description">列描述</param>
        public void AddColumn(string column, Type type, string description)
        {
            this.columns.Add(column);
            this.columnTypes.Add(type);
            this.columnDescription.Add(description);
        }

        /// <summary>
        /// 添加列定义
        /// </summary>
        /// <param name="properties">属性描述</param>
        public void AddColumns(List<PoseidonProperty> properties)
        {
            foreach(var item in properties)
            {
                this.columns.Add(item.Name);
                this.columnTypes.Add(PoseidonUtil.GetPropertyType(item.Type));
                this.columnDescription.Add(item.Remark);
            }
        }

        public PoseidonObject Add(params string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");
            if (args.Length != this.columns.Count)
                throw new ArgumentException("参数错误");

            PoseidonObject obj = new PoseidonObject();
            for (int i = 0; i < args.Length; i++)
            {
                obj[this.columns[i]] = args[i];
            }
            Add(obj);
            return obj;
        }


        //public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        //{
        //    if (listAccessors == null || listAccessors.Length == 0)
        //    {                
        //        PropertyDescriptor[] props = new PropertyDescriptor[this.columns.Count];
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            props[i] = new PoseidonPropertyDescriptor(this.columns[i]);
        //        }
        //        return new PropertyDescriptorCollection(props, true);
        //    }
        //    throw new NotImplementedException("Relations not implemented");
        //}

        /// <summary>
        /// 设置项属性
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length == 0)
            {
                PropertyDescriptor[] props = new PropertyDescriptor[this.columns.Count];
                for (int i = 0; i < props.Length; i++)
                {
                    DisplayNameAttribute display = new DisplayNameAttribute(this.columnDescription[i]);

                    props[i] = new PoseidonPropertyDescriptor(this.columns[i], this.columnTypes[i], new Attribute[] { display });
                }
                return new PropertyDescriptorCollection(props, true);
            }
            throw new NotImplementedException("Relations not implemented");
        }

        /// <summary>
        /// 获取列表名称
        /// </summary>
        /// <param name="listAccessors"></param>
        /// <returns></returns>
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "PoseidonObjectList";
        }
        #endregion //Method

        #region Property

        public List<string> Columns
        {
            get
            {
                return this.columns;
            }
        }
        #endregion //Property
    }
}
