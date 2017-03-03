using System;
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
    /// 组织选择窗体
    /// </summary>
    public partial class FrmOrganizationSelect : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 当前关联分组
        /// </summary>
        private Group currentGroup;

        /// <summary>
        /// 分组关联组织
        /// </summary>
        private List<Organization> relateOrganizations;
        #endregion //Field

        #region Constructor
        public FrmOrganizationSelect(string groupId)
        {
            InitializeComponent();

            InitData(groupId);
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            LoadModelTypes();
            LoadOrganizations();

            base.InitForm();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="groupId">分组ID</param>
        private void InitData(string groupId)
        {
            this.currentGroup = BusinessFactory<GroupBusiness>.Instance.FindById(groupId);
        }

        /// <summary>
        /// 载入关联模型类型
        /// </summary>
        private void LoadModelTypes()
        {
            var data = BusinessFactory<ModelTypeBusiness>.Instance.FindWithCodes(this.currentGroup.ModelTypes).ToList();
            this.bsModelType.DataSource = data;
        }

        /// <summary>
        /// 载入已有组织
        /// </summary>
        private void LoadOrganizations()
        {
            this.relateOrganizations = BusinessFactory<OrganizationBusiness>.Instance.FindWithIds(this.currentGroup.Organizations).ToList();
            this.ogridRight.DataSource = this.relateOrganizations;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 模型类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luModelTypes_EditValueChanged(object sender, EventArgs e)
        {
            if (this.luModelTypes.EditValue == null)
                return;

            this.ogridLeft.DataSource = BusinessFactory<OrganizationBusiness>.Instance.FindByModelType(this.luModelTypes.EditValue.ToString()).ToList();
        }

        /// <summary>
        /// 移入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveIn_Click(object sender, EventArgs e)
        {
            var select = this.ogridLeft.GetCurrentSelect();
            if (select != null && !this.relateOrganizations.Any(r => r.Id == select.Id))
            {
                this.relateOrganizations.Add(select);
                this.ogridRight.UpdateBindingData();
            }
        }

        /// <summary>
        /// 移出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoveOut_Click(object sender, EventArgs e)
        {
            var select = this.ogridRight.GetCurrentSelect();
            if (select != null)
            {
                this.relateOrganizations.Remove(select);
                this.ogridRight.UpdateBindingData();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var orgIds = this.ogridRight.DataSource.Select(r => r.Id).ToList();

            try
            {
                BusinessFactory<GroupBusiness>.Instance.SetOrganizations(this.currentGroup.Id, orgIds);

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
