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

        #region Event
        /// <summary>
        /// 树形菜单双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var info = this.tlGroup.CalcHitInfo(this.tlGroup.PointToClient(MousePosition));

            if (info.Node != null)
            {    
                GroupSelected?.Invoke(sender, e);
            }
        }
        #endregion //Event

        #region Delegate
        /// <summary>
        /// 分组选择事件
        /// </summary>
        [Description("分组选择事件")]
        public event Action<object, EventArgs> GroupSelected;
        #endregion //Delegate

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
