﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Common;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 对象模型编辑窗体
    /// </summary>
    public partial class FrmObjectModelEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联对象
        /// </summary>
        private ObjectModel currentModel;
        #endregion //Field

        #region Constructor
        public FrmObjectModelEdit(string id)
        {
            InitializeComponent();

            this.currentModel = BusinessFactory<ObjectModelBusiness>.Instance.FindById(id);
        }
        #endregion //Constructor

        #region Function
        private void InitControls()
        {
            this.txtKey.Text = this.currentModel.Key;
            this.txtName.Text = this.currentModel.Name;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmObjectModelEdit_Load(object sender, EventArgs e)
        {
            InitControls();
        }
        #endregion //Event
    }
}
