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
        #endregion //Field

        #region Constructor
        public FrmOrganizationSelect(string groupId)
        {
            InitializeComponent();

            LoadEntity(groupId);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入关联对象
        /// </summary>
        /// <param name="groupId">分组ID</param>
        private void LoadEntity(string groupId)
        {
            this.currentGroup = BusinessFactory<GroupBusiness>.Instance.FindById(groupId);
        }

        /// <summary>
        /// 载入关联模型类型
        /// </summary>
        private void LoadModelTypes()
        {
            List<ModelType> data = new List<ModelType>();
            foreach (var item in this.currentGroup.ModelTypes)
            {
                var mt = BusinessFactory<ModelTypeBusiness>.Instance.FindByCode(item);
                data.Add(mt);
            }

            this.bsModelType.DataSource = data;
        }

        protected override void InitControls()
        {
            LoadModelTypes();
        }
        #endregion //Function
    }
}
