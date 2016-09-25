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
        private void barBtnEnergy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmEnergyObject));
        }

        private void barBtnEnergyAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmModelAdd), new object[] { CustomModelType.Energy });
        }


        private void barBtnOrganizationList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmOrganizationModel));
        }

        private void barBtnOrganizationAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmModelAdd), new object[] { CustomModelType.Organization });
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
