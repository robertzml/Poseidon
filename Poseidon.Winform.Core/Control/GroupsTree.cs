using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Core
{
    using Poseidon.Core.DL;

    /// <summary>
    /// 分组树形控件
    /// </summary>
    public partial class GroupsTree : DevExpress.XtraEditors.XtraUserControl
    {
        #region Constructor
        public GroupsTree()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取当前选中项
        /// </summary>
        /// <returns></returns>
        public Group GetCurrentSelect()
        {
            var node = this.tlGroup.Selection[0];

            if (node == null)
                return null;

            var data = this.bsGroup[node.Id] as Group;
            return data;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Group> DataSource
        {
            get
            {
                return this.bsGroup.DataSource as List<Group>;
            }
            set
            {
                this.tlGroup.BeginInit();
                this.bsGroup.DataSource = value;
                this.tlGroup.EndInit();
            }
        }
        #endregion //Property
    }
}
