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
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 绑定模型类型窗体
    /// </summary>
    /// <remarks>
    /// 用于分组与模型类型关联
    /// </remarks>
    public partial class FrmModelTypeBind : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 分组ID
        /// </summary>
        private string groupId;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 绑定模型类型窗体
        /// </summary>
        /// <param name="groupId">分组ID</param>
        public FrmModelTypeBind(string groupId)
        {
            InitializeComponent();

            this.groupId = groupId;
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            LoadModelType();

            base.InitForm();
        }

        private void LoadModelType()
        {
            var data = BusinessFactory<ModelTypeBusiness>.Instance.FindAll().ToList();

            this.clbModelTypes.DataSource = data;
            this.clbModelTypes.DisplayMember = "Name";
            this.clbModelTypes.ValueMember = "Id";
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();
            var checkedItems = this.clbModelTypes.CheckedItems;
            foreach(var item in checkedItems)
            {
                var mt = item as ModelType;
                codes.Add(mt.Code);
            }

            try
            {
                BusinessFactory<GroupBusiness>.Instance.SetModelTypes(this.groupId, codes);

                MessageUtil.ShowInfo("保存成功");
                this.Close();
            }
            catch(PoseidonException pe)
            {
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
