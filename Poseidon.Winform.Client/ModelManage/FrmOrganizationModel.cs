﻿using System;
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
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 组织模型总览窗体
    /// </summary>
    public partial class FrmOrganizationModel : BaseForm
    {
        #region Constructor
        public FrmOrganizationModel()
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
        private void FrmOrganizationModel_Load(object sender, EventArgs e)
        {
            var data = BusinessFactory<CustomModelBusiness>.Instance.FindByType(CustomModelType.Organization);
            this.dgModel.DataSource = data;
        }
        #endregion //Event
    }
}