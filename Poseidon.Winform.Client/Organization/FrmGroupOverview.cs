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
        #region Field
        /// <summary>
        /// 当前选中分组
        /// </summary>
        private Group currentGroup;
        #endregion //Field

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
            LoadGroupsTree();
        }

        /// <summary>
        /// 载入分组树形列表
        /// </summary>
        private void LoadGroupsTree()
        {
            var groups = BusinessFactory<GroupBusiness>.Instance.FindAll().ToList();
            this.trGroup.DataSource = groups;
        }

        /// <summary>
        /// 设置分组基本信息
        /// </summary>
        private void SetGroupInfo()
        {
            this.txtName.Text = this.currentGroup.Name;
            this.txtCode.Text = this.currentGroup.Code;
            this.txtStatus.Text = this.currentGroup.Status.ToString();
            this.txtRemark.Text = this.currentGroup.Remark;
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
            this.currentGroup = this.trGroup.GetCurrentSelect();
            if (this.currentGroup == null)
                return;

            SetGroupInfo();
        }

        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var children = BusinessFactory<GroupBusiness>.Instance.FindChildren(this.currentGroup.Id);

            return;
            ChildFormManage.ShowDialogForm(typeof(FrmGroupAdd));
            LoadGroupsTree();
        }
        #endregion //Event

    }
}
