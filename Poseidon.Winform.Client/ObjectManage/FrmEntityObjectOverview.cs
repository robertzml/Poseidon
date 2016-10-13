using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using DevExpress.XtraTreeList.Nodes;
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 实体对象总览窗体
    /// </summary>
    public partial class FrmEntityObjectOverview : BaseForm
    {
        #region Constructor
        public FrmEntityObjectOverview()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入模型树列表
        /// </summary>
        private void LoadTree()
        {
            var data = BusinessFactory<EntityModelBusiness>.Instance.FindAll();
            this.tlEntityModel.DataSource = data;
        }

        private void SetModelBaseInfo(EntityModel model)
        {
            this.txtKey.Text = model.Key;
            this.txtName.Text = model.Name;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEntityObjectOverview_Load(object sender, EventArgs e)
        {
            LoadTree();
        }


        private void tlEntityModel_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            var data = this.tlEntityModel.DataSource as List<EntityModel>;
            if (data[e.Node.Id].IsAbstract)
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectImageIndex = 0;
            }
            else
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectImageIndex = 1;
            }
        }

        /// <summary>
        /// 选中模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlEntityModel_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            var data = this.tlEntityModel.DataSource as List<EntityModel>;
            var model = data[e.Node.Id];

            SetModelBaseInfo(model);
        }
        #endregion //Event
    }
}
