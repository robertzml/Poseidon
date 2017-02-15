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

        #region Event
        /// <summary>
        /// 注册模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmModelTypeAdd));
        }
        #endregion //Event
    }
}
