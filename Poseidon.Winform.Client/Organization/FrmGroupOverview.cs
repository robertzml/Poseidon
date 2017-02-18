using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 分组总览窗体
    /// </summary>
    public partial class FrmGroupOverview : BaseMdiForm
    {
        #region Constructor
        public FrmGroupOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        protected override void InitControls()
        {
            LoadGroups();
        }

        /// <summary>
        /// 载入分组
        /// </summary>
        private void LoadGroups()
        {
            var groups = BusinessFactory<GroupBusiness>.Instance.FindAll().ToList();
            this.trGroup.DataSource = groups;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGroupOverview_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选择分组
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void trGroup_GroupSelected(object arg1, EventArgs arg2)
        {
            var group = this.trGroup.GetCurrentSelect();
            if (group == null)
                return;

            this.txtName.Text = group.Name;
            this.txtCode.Text = group.Code;
            this.txtStatus.Text = group.Status.ToString();
            this.txtRemark.Text = group.Remark;
        }

        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmGroupAdd));
            LoadGroups();
        }
        #endregion //Event

    }
}
