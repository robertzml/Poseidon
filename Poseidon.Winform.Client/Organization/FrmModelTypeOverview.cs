using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 模型类型总览窗体
    /// </summary>
    public partial class FrmModelTypeOverview : BaseMdiForm
    {
        #region Constructor
        public FrmModelTypeOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入模型类型
        /// </summary>
        private void LoadModelType()
        {
            var data = BusinessFactory<ModelTypeBusiness>.Instance.FindAll().ToList();
            this.mtGrid.DataSource = data;
        }

        protected override void InitForm()
        {
            LoadModelType();
            base.InitForm();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 注册模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmModelTypeAdd));
            LoadModelType();
        }

        /// <summary>
        /// 编辑模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var select = this.mtGrid.GetCurrentSelect();
            if (select == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmModelTypeEdit), new object[] { select.Id });
            LoadModelType();
        }
        #endregion //Event
    }
}
