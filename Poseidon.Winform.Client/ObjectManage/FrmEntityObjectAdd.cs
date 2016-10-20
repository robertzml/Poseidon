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

        private void FrmEntityObjectAdd_Load(object sender, EventArgs e)
        {
            PoseidonObjectList list = new PoseidonObjectList();

            foreach (var item in model.Properties)
            {
                list.AddColumn(item.Name, item.Remark);
            }

            list.Add(new PoseidonObject());

            this.vGridControl1.DataSource = list;

            //this.vGridControl1.Rows.Add()
        }
    }
}
