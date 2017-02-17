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
    using Poseidon.Winform.Core;

    /// <summary>
    /// 分组添加窗体
    /// </summary>
    public partial class FrmGroupAdd : BaseSingleForm
    {
        #region Constructor
        public FrmGroupAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化控件
        /// </summary>
        protected override void InitControls()
        {
            var groups = BusinessFactory<GroupBusiness>.Instance.FindAll();
            this.trGroup.DataSource = groups.ToList();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="entity"></param>
        private void SetEntity(Group entity)
        {
            entity.Name = this.txtName.Text;
            entity.Code = this.txtCode.Text;
            entity.Remark = this.txtRemark.Text;

            var parent = pcParentGroup.Tag;
            if (parent != null)
                entity.ParentId = ((Group)parent).Id;
            else
                entity.ParentId = null;

            entity.Status = 0;
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

            return new Tuple<bool, string>(true, "");
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGroupAdd_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 分组选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trGroup_GroupSelected(object sender, EventArgs e)
        {
            var group = this.trGroup.GetCurrentSelect();
            this.pcParentGroup.Text = group.Name;
            this.pcParentGroup.Tag = group;
            this.pcParentGroup.ClosePopup();
        }

        /// <summary>
        /// 所属分组弹出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcParentGroup_QueryPopUp(object sender, CancelEventArgs e)
        {
            pcGroups.Width = this.pcParentGroup.Width;
        }

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

            Group entity = new Group();
            SetEntity(entity);

            try
            {
                BusinessFactory<GroupBusiness>.Instance.Create(entity);

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
