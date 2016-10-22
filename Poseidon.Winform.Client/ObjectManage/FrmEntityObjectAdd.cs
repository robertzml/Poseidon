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
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Common;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 实体对象添加窗体
    /// </summary>
    public partial class FrmEntityObjectAdd : BaseSingleForm
    {
        #region Field
        private EntityModel model;
        #endregion //Field

        #region Constructor
        public FrmEntityObjectAdd(EntityModel model)
        {
            InitializeComponent();

            this.model = model;
        }
        #endregion //Constructor

        #region Event
        private void FrmEntityObjectAdd_Load(object sender, EventArgs e)
        {
            PoseidonObjectList list = new PoseidonObjectList();

            list.AddColumns(model.Properties);

            list.Add(new PoseidonObject());

            this.wvgData.DataSource = list;
        }
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.wvgData.CloseEditor();

            var data = this.wvgData.DataSource;


        }
        #endregion //Event
    }
}
