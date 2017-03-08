﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 字典总览
    /// </summary>
    public partial class FrmDictOverview : BaseMdiForm
    {
        #region Field
        /// <summary>
        /// 当前字典分类
        /// </summary>
        private DictCategory currentCategory;

        /// <summary>
        /// 当前字典
        /// </summary>
        private Dict currentDict;
        #endregion //Field

        #region Constructor
        public FrmDictOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 选择分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeDict_CategorySelected(object sender, EventArgs e)
        {
            string id = this.treeDict.GetCurrentSelectCategoryId();
            if (id == null)
                return;

            this.currentCategory = BusinessFactory<DictCategoryBusiness>.Instance.FindById(id);
            this.txtName.Text = this.currentCategory.Name;
            this.txtRemark.Text = this.currentCategory.Remark;
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmDictCategoryAdd));
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategoryEdit_Click(object sender, EventArgs e)
        {
            if (this.currentCategory == null)
                return;

            ChildFormManage.ShowDialogForm(typeof(FrmDictCategoryEdit), new object[] { this.currentCategory.Id });
        }


        private void btnCategoryDelete_Click(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
