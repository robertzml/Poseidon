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
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 编辑模型类型窗体
    /// </summary>
    public partial class FrmModelTypeEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联实体
        /// </summary>
        private ModelType currentEntity;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 编辑模型类型窗体
        /// </summary>
        /// <param name="id">模型类型ID</param>
        public FrmModelTypeEdit(string id)
        {
            InitializeComponent();

            InitData(id);
        }
        #endregion //Constructor

        #region Function
        private void InitData(string id)
        {
            this.currentEntity = BusinessFactory<ModelTypeBusiness>.Instance.FindById(id);
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        protected override void InitForm()
        {
            this.txtName.Text = this.currentEntity.Name;
            this.txtCode.Text = this.currentEntity.Code;
            this.txtRemark.Text = this.currentEntity.Remark;

            base.InitForm();
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                errorMessage = "名称不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="model"></param>
        private void SetEntity(ModelType model)
        {
            model.Name = this.txtName.Text;
            model.Remark = this.txtRemark.Text;
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
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            SetEntity(this.currentEntity);

            try
            {
                BusinessFactory<ModelTypeBusiness>.Instance.Update(this.currentEntity);

                MessageUtil.ShowInfo("保存成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
