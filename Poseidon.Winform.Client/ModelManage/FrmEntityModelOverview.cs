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
    /// 实体模型总览窗体
    /// </summary>
    public partial class FrmEntityModelOverview : BaseForm
    {
        #region Constructor
        public FrmEntityModelOverview()
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
            string displayColumns = "Key,Name,Base,IsAbstract,CollectionName,Remark";
            string displayHeaders = "标识,名称,继承基类,是否抽象类,存储集合,备注";
            this.wdgList.SetColumnPairs(displayColumns, displayHeaders);

            displayColumns = "Name,Type,Remark";
            displayHeaders = "名称,类型,备注";
            this.wdgProperty.SetColumnPairs(displayColumns, displayHeaders);
        }

        /// <summary>
        /// 载入所有实体模型
        /// </summary>
        private void LoadData()
        {
            var data = BusinessFactory<EntityModelBusiness>.Instance.FindAll();
            this.wdgList.DataSource = data;
        }

        private void LoadProperty()
        {
            var data = this.wdgList.GetSelected() as EntityModel;
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

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            var data = this.wdgList.GetSelected() as EntityModel;
            if (data == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmEntityModelEdit), new object[] { data.Id });
        }
       

        private void wdgList_GridFocusedRowChanged(object sender, EventArgs e)
        {
            LoadProperty();
        }
        #endregion //Event

     
    }
}
