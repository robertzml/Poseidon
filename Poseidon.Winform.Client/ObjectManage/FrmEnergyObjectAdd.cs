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

        #region Event

        private void FrmEnergyObjectAdd_Load(object sender, EventArgs e)
        {
            this.dgProperty.DataSource = new List<ModelProperty>();

            this.bsModel.DataSource = BusinessFactory<EnergyModelBusiness>.Instance.FindAll();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.dgProperty.CloseEditor();

            EnergyModel model = new EnergyModel();
            model.Key = this.txtKey.Text;
            model.Name = this.txtName.Text;
            model.Base = "EnergyModel";
            model.Remark = this.txtRemark.Text;

            var result = BusinessFactory<EnergyModelBusiness>.Instance.Create(model, this.dgProperty.DataSource);

            MessageBox.Show(result.ToString());
        }
        #endregion //Event

    }
}
