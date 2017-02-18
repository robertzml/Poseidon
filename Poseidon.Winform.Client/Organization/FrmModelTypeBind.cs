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
    using DevExpress.XtraEditors;
    using Poseidon.Base.Framework;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 绑定模型类型窗体
    /// </summary>
    /// <remarks>
    /// 用于分组与模型类型关联
    /// </remarks>
    public partial class FrmModelTypeBind : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 分组ID
        /// </summary>
        private string groupId;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 绑定模型类型窗体
        /// </summary>
        /// <param name="groupId">分组ID</param>
        public FrmModelTypeBind(string groupId)
        {
            InitializeComponent();

            this.groupId = groupId;
        }
        #endregion //Constructor

        #region Function
        protected override void InitControls()
        {
            LoadModelType();
        }

        private void LoadModelType()
        {
            var data = BusinessFactory<ModelTypeBusiness>.Instance.FindAll().ToList();

            this.clbModelTypes.DataSource = data;
            this.clbModelTypes.DisplayMember = "Name";
            this.clbModelTypes.ValueMember = "Id";
        }
        #endregion //Function

        #region Event
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> codes = new List<string>();
            var checkedItems = this.clbModelTypes.CheckedItems;
            foreach(var item in checkedItems)
            {
                var mt = item as ModelType;
                codes.Add(mt.Code);
            }

            BusinessFactory<GroupBusiness>.Instance.AddModelTypes(this.groupId, codes);
        }
        #endregion //Event
    }
}
