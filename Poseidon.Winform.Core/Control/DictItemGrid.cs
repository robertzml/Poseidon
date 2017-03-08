using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Core
{
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 字典项表格控件
    /// </summary>
    public partial class DictItemGrid : WinEntityGrid<DictItem>
    {
        #region Field
        /// <summary>
        /// 是否显示导航
        /// </summary>
        private bool showNavigator;
        #endregion //Field

        #region Constructor
        public DictItemGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DictItemGrid_Load(object sender, EventArgs e)
        {
            this.dataNavigator1.Visible = this.showNavigator;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 是否显示导航条
        /// </summary>
        [Category("界面"), Description("是否显示导航条"), Browsable(true)]
        public bool ShowNavigator
        {
            get
            {
                return this.showNavigator;
            }
            set
            {
                this.showNavigator = value;
            }
        }
        #endregion //Property
    }
}
