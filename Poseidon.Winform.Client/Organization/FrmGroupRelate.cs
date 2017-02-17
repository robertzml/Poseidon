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
        #endregion //Function

        #region Event
        private void FrmGroupRelate_Load(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
