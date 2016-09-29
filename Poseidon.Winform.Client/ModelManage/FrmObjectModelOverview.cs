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

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmObjectModelOverview_Load(object sender, EventArgs e)
        {
            var data = BusinessFactory<ObjectModelBusiness>.Instance.FindAll();
            this.wdgList.DataSource = data;
        }
        #endregion //Event
    }
}
