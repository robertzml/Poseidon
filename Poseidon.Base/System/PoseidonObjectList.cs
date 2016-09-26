using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base
{
    /// <summary>
    /// 自定义属性的动态对象
    /// </summary>
    public class PoseidonObjectList : List<PoseidonObject>, ITypedList
    {
        #region Field
        private List<string> columns;
        #endregion //Field                

        #region Constructor
        public PoseidonObjectList()
        {
            this.columns = new List<string>();
        }
        #endregion //Constructor

        #region Method
        public PoseidonObject Add(params string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");
            if (args.Length != Columns.Count) throw new ArgumentException("args");
            PoseidonObject bag = new PoseidonObject();
            for (int i = 0; i < args.Length; i++)
            {
                bag[Columns[i]] = args[i];
            }
            Add(bag);
            return bag;
        }

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (listAccessors == null || listAccessors.Length == 0)
            {
                PropertyDescriptor[] props = new PropertyDescriptor[Columns.Count];
                for (int i = 0; i < props.Length; i++)
                {
                    props[i] = new PoseidonPropertyDescriptor(Columns[i]);
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
