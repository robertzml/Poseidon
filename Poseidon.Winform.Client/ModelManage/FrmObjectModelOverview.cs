using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 对象模型总览窗体
    /// </summary>
    public partial class FrmObjectModelOverview : BaseForm
    {
        #region Constructor
        public FrmObjectModelOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void InitControls()
        {
            string displayColumns = "Key,Name,Base,IsAbstract,Remark";
            string displayHeaders = "标识,名称,继承基类,是否抽象类,备注";
            this.wdgList.SetColumnPairs(displayColumns, displayHeaders);

            displayColumns = "Name,Type,Remark";
            displayHeaders = "名称,类型,备注";
            this.wdgProperty.SetColumnPairs(displayColumns, displayHeaders);
        }

        private void LoadData()
        {
            var data = BusinessFactory<ObjectModelBusiness>.Instance.FindAll();
            this.wdgList.DataSource = data;
        }

        private void LoadProperty()
        {
            var data = this.wdgList.GetSelected() as ObjectModel;
            this.wdgProperty.DataSource = data.Properties;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmObjectModelOverview_Load(object sender, EventArgs e)
        {
            InitControls();
            LoadData();
        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var data = this.wdgList.GetSelected() as ObjectModel;
            if (data == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmObjectModelEdit), new object[] { data.Id });
        }
       

        private void wdgList_GridFocusedRowChanged(object sender, EventArgs e)
        {
            LoadProperty();
        }
        #endregion //Event
    }
}
