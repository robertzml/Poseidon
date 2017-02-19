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
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 分组关联窗体
    /// </summary>
    public partial class FrmGroupRelate : BaseMdiForm
    {
        #region Field
        /// <summary>
        /// 选中分组
        /// </summary>
        private Group currentGroup;
        #endregion //Field

        #region Constructor
        public FrmGroupRelate()
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
            // init groups tree
            var groups = BusinessFactory<GroupBusiness>.Instance.FindAll().ToList();
            this.trGroup.DataSource = groups;

            // load model types
            var types = BusinessFactory<ModelTypeBusiness>.Instance.FindAll().ToList();
            this.bsModelType.DataSource = types;
        }

        /// <summary>
        /// 载入分组关联模型类型
        /// </summary>
        private void LoadModelTypes()
        {
            List<ModelType> data = new List<ModelType>();
            foreach (var item in this.currentGroup.ModelTypes)
            {
                var mt = BusinessFactory<ModelTypeBusiness>.Instance.FindByCode(item);
                data.Add(mt);
            }

            this.mtGrid.DataSource = data;
        }
        #endregion //Function

        #region Event
        private void FrmGroupRelate_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 选择分组
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void trGroup_GroupSelected(object arg1, EventArgs arg2)
        {
            var group = this.trGroup.GetCurrentSelect();
            if (group == null)
                return;

            this.txtName.Text = group.Name;
            this.txtCode.Text = group.Code;
            this.txtStatus.Text = group.Status.ToString();
            this.txtRemark.Text = group.Remark;

            this.currentGroup = group;

            LoadModelTypes();
        }

        /// <summary>
        /// 绑定模型类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModelTypeBind_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmModelTypeBind), new object[] { this.currentGroup.Id });
        }
        #endregion //Event

    }
}
