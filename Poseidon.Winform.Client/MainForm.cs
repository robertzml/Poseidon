using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using DevExpress.XtraBars.Ribbon;
    using Poseidon.Common;
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

        #region Target
        /// <summary>
        /// 指标总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiTargetOverview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string assemblyName = "Poseidon.Energy.ClientDx";
            string typeName = "Poseidon.Energy.ClientDx.FrmTargetOverview";

            ChildFormManage.LoadMdiForm(this, assemblyName, typeName);
        }

        /// <summary>
        /// 部门总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDepartmentOv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string assemblyName = "Poseidon.Energy.ClientDx";
            string typeName = "Poseidon.Energy.ClientDx.FrmDepartmentOverview";

            ChildFormManage.LoadMdiForm(this, assemblyName, typeName);
        }

        /// <summary>
        /// 人数统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiPopulation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string assemblyName = "Poseidon.Energy.ClientDx";
            string typeName = "Poseidon.Energy.ClientDx.FrmPopulationOverview";

            ChildFormManage.LoadMdiForm(this, assemblyName, typeName);
        }

        /// <summary>
        /// 经费统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiFund_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string assemblyName = "Poseidon.Energy.ClientDx";
            string typeName = "Poseidon.Energy.ClientDx.FrmFundOverview";

            ChildFormManage.LoadMdiForm(this, assemblyName, typeName);
        }
        #endregion //Target

        /// <summary>
        /// 支出账户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiExpenseAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string assemblyName = "Poseidon.Expense.ClientDx";
            string typeName = "Poseidon.Expense.ClientDx.FrmWaterAccountOverview";

            var form = Reflect<BaseMdiForm>.Create(typeName, assemblyName);
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// 模型类型总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiModelTypeOv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmModelTypeOverview));
        }

        /// <summary>
        /// 分组总览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiGroupOv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmGroupOverview));
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
