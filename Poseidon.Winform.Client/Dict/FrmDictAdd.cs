using System;
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
    using Poseidon.Common;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 添加字典
    /// </summary>
    public partial class FrmDictAdd : BaseSingleForm
    {
        #region Constructor
        public FrmDictAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Funtion
        protected override void InitForm()
        {
            this.bsCategory.DataSource = BusinessFactory<DictCategoryBusiness>.Instance.FindAll();
            this.itemGrid.DataSource = new List<DictItem>();

            base.InitForm();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(Dict entity)
        {
            entity.Name = this.txtName.Text;
            entity.Code = this.txtCode.Text;
            entity.CategoryId = this.luCategory.EditValue.ToString();
            entity.Items = this.itemGrid.DataSource;
            entity.Remark = this.txtRemark.Text;

            foreach (var item in entity.Items)
            {
                item.Remark = item.Remark ?? "";
            }
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

            if (string.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                errorMessage = "代码不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            if (this.luCategory.EditValue == null)
            {
                errorMessage = "请选择分类";
                return new Tuple<bool, string>(false, errorMessage);
            }

            foreach (var item in this.itemGrid.DataSource)
            {
                if (string.IsNullOrEmpty(item.Value))
                {
                    errorMessage = "字典值不能为空";
                    return new Tuple<bool, string>(false, errorMessage);
                }
            }

            return new Tuple<bool, string>(true, "");
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
            this.itemGrid.CloseEditor();

            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            Dict entity = new Dict();
            SetEntity(entity);

            try
            {
                BusinessFactory<DictBusiness>.Instance.Create(entity);

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
