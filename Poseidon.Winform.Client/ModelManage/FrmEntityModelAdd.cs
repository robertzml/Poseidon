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
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Common;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 实体模型添加窗体
    /// </summary>
    public partial class FrmEntityModelAdd : BaseSingleForm
    {
        #region Constructor
        public FrmEntityModelAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="model"></param>
        private void SetEntity(EntityModel model)
        {
            model.Key = this.txtKey.Text;
            model.Name = this.txtName.Text;
            model.Base = this.lkuInherit.EditValue.ToString();
            model.IsAbstract = this.chkAbstract.Checked;
            model.Remark = this.txtRemark.Text;

            model.Properties = new List<PoseidonProperty>();
            if (this.dgInherit.DataSource != null && this.dgInherit.DataSource.Count > 0)
            {
                model.Properties.AddRange(this.dgInherit.DataSource);
            }
            if (this.dgProperty.DataSource.Count > 0)
                model.Properties.AddRange(this.dgProperty.DataSource);
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (string.IsNullOrEmpty(this.txtKey.Text.Trim()))
            {
                errorMessage = "模型标识不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                errorMessage = "模型名称不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            if (this.lkuInherit.EditValue == null)
            {
                errorMessage = "继承模型不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmObjectModelAdd_Load(object sender, EventArgs e)
        {
            this.bsEntityModel.DataSource = BusinessFactory<EntityModelBusiness>.Instance.FindAll();
            this.dgProperty.DataSource = new List<PoseidonProperty>();
        }

        /// <summary>
        /// 继承模型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkuInherit_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkuInherit.EditValue == null)
            {
                this.dgInherit.DataSource = null;
                return;
            }

            var model = BusinessFactory<EntityModelBusiness>.Instance.FindByKey(this.lkuInherit.EditValue.ToString());
            this.dgInherit.DataSource = model.Properties;
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.dgProperty.CloseEditor();

            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            EntityModel model = new EntityModel();
            SetEntity(model);

            var result = BusinessFactory<EntityModelBusiness>.Instance.Create(model);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加模型成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加模型失败，" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
