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
    /// 编辑字典分类窗体
    /// </summary>
    public partial class FrmDictCategoryEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联分类
        /// </summary>
        private DictCategory currentCategory;
        #endregion //Field

        #region Constructor
        public FrmDictCategoryEdit(string id)
        {
            InitializeComponent();

            InitData(id);
        }
        #endregion //Constructor

        #region Function
        private void InitData(string id)
        {
            this.currentCategory = BusinessFactory<DictCategoryBusiness>.Instance.FindById(id);
        }

        protected override void InitForm()
        {
            this.txtName.Text = this.currentCategory.Name;
            this.txtRemark.Text = this.currentCategory.Remark;
            base.InitForm();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(DictCategory entity)
        {
            entity.Name = this.txtName.Text;
            entity.Remark = this.txtRemark.Text;
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
        #endregion //Function

        #region Event
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            SetEntity(this.currentCategory);

            try
            {
                BusinessFactory<DictCategoryBusiness>.Instance.Update(this.currentCategory);

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
