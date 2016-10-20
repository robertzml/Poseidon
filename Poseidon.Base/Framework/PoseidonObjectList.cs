using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Base.Framework
{
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
        public void AddColumn(string column, string description)
        {
            this.columns.Add(column);
            this.columnDescription.Add(description);            
        }

        public void AddType(Type type)
        {
            this.columnTypes.Add(type);
        }

        public void SetColumnPairs(string columns, string descriptions)
        {
            string[] names = columns.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] headers = descriptions.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (names.Length != headers.Length)
                throw new ArgumentException("动态对象列配置有误");

            for (int i = 0; i < names.Length; i++)
            {
                this.columns.Add(names[i]);
                this.columnDescription.Add(headers[i]);
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


        public void AddObject(PoseidonObject obj)
        {
            //foreach(var item in obj.Fields)
            //{
            //    obj[item]
            //}
            base.Add(obj);
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

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length == 0)
            {
                PropertyDescriptor[] props = new PropertyDescriptor[this.columns.Count];
                for (int i = 0; i < props.Length; i++)
                {
                    props[i] = new PoseidonPropertyDescriptor(this.columns[i], this.columnTypes[i], null);
                }
                return new PropertyDescriptorCollection(props, true);
            }
            throw new NotImplementedException("Relations not implemented");
        }

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
