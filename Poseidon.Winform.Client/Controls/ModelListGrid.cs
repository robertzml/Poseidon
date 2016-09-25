using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using DevExpress.XtraGrid.Views.Grid;
    using Poseidon.Core.DL;

    /// <summary>
    /// 模型列表控件
    /// </summary>
    public partial class ModelListGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 关联对象
        /// </summary>
        private BindingSource bsData;

        /// <summary>
        /// 对应表格视图
        /// </summary>
        private GridView dgView;
        #endregion //Field

        #region Constructor
        public ModelListGrid()
        {
            InitializeComponent();

            this.bsData = this.bsModel;
            this.dgView = this.dgvModel;
        }
        #endregion //Constructor

        #region Event
        private void ModelListGrid_Load(object sender, EventArgs e)
        {

        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<CustomModel> DataSource
        {
            get
            {
                return this.bsData.DataSource as List<CustomModel>;
            }
            set
            {
                this.dgvModel.BeginDataUpdate();
                this.bsData.DataSource = value;
                this.dgvModel.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
