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
    using DevExpress.XtraBars.Ribbon;
    using Poseidon.Common;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 主窗体界面
    /// </summary>
    public partial class MainForm : RibbonForm
    {
        #region Field

        #endregion //Field

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = AppConfig.ApplicationName;
        }

        #region Ribbon Event
        /// <summary>
        /// 实体模型总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEntityModelOverview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmEntityModelOverview));
        }

        /// <summary>
        /// 添加实体模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEntityModelAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmEntityModelAdd));
        }


        /// <summary>
        /// 实体对象总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEntityObjectOverview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmEntityObjectOverview));
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion //Ribbon Event

        #endregion //Event
    }
}
