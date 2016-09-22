using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Model;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 添加能源模型
    /// </summary>
    public partial class FrmEnergyObjectAdd : BaseSingleForm
    {
        #region Constructor
        public FrmEnergyObjectAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="model"></param>
        private void SetEntity(EnergyModel model)
        {
            model.Key = this.txtKey.Text;
            model.Name = this.txtName.Text;
            model.Base = this.lkuInherit.EditValue.ToString();
            model.Type = CustomModelType.Energy;
            model.Remark = this.txtRemark.Text;
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        private bool CheckInput(out string errorMessage)
        {
            errorMessage = "";

            if (string.IsNullOrEmpty(this.txtKey.Text.Trim()))
            {
                errorMessage = "模型标识不能为空";
                return false;
            }

            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                errorMessage = "模型名称不能为空";
                return false;
            }

            if (this.lkuInherit.EditValue == null)
            {
                errorMessage = "继承模型不能为空";
                return false;
            }

            return true;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEnergyObjectAdd_Load(object sender, EventArgs e)
        {
            this.dgProperty.DataSource = new List<ModelProperty>();

            this.bsModel.DataSource = BusinessFactory<EnergyModelBusiness>.Instance.FindAll();
        }

        /// <summary>
        /// 继承类型选择
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

            var list = this.bsModel.DataSource as List<EnergyModel>;
            var select = list.Single(r => r.Key == this.lkuInherit.EditValue.ToString());

            var model = BusinessFactory<EnergyModelBusiness>.Instance.FindById(select.Id);

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

            string errorMessage;
            if (!CheckInput(out errorMessage))
            {
                MessageUtil.ShowError(errorMessage);
                return;
            }

            EnergyModel model = new EnergyModel();
            SetEntity(model);

            var result = BusinessFactory<EnergyModelBusiness>.Instance.Create(model, this.dgProperty.DataSource);

            MessageBox.Show(result.ToString());
        }
        #endregion //Event
    }
}
