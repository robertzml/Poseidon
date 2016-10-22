using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    /// <summary>
    /// 列表格控件
    /// </summary>
    public partial class WinVerticalGrid : DevExpress.XtraEditors.XtraUserControl
    {
        #region Field
        /// <summary>
        /// 绑定数据源
        /// </summary>
        private BindingSource bindingSource;

        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable;
        #endregion //Field

        #region Constructor
        public WinVerticalGrid()
        {
            InitializeComponent();

            this.bindingSource = new BindingSource();
        }
        #endregion //Constructor

        #region Method
        public void CloseEditor()
        {
            this.dgcData.CloseEditor();
        }
        #endregion //Method

        #region Event
        private void WinVerticalGrid_Load(object sender, EventArgs e)
        {
            this.dgcData.OptionsBehavior.Editable = this.editable;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public object DataSource
        {
            get
            {
                return this.bindingSource.DataSource;
            }
            set
            {
                this.dgcData.BeginDataUpdate();
                this.bindingSource.DataSource = value;
                if (value == null)
                {
                    this.dgcData.DataSource = null;
                }
                else
                {
                    this.dgcData.DataSource = bindingSource;
                }

                this.dgcData.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Description("是否能编辑")]
        public bool Editable
        {
            get
            {
                return this.editable;
            }
            set
            {
                this.editable = value;
            }
        }
        #endregion //Property
    }
}
