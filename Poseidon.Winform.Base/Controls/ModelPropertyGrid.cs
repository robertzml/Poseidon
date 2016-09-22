using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    using DevExpress.XtraGrid.Views.Grid;
    using Poseidon.Model;

    /// <summary>
    /// 模型属性表格控件
    /// </summary>
    public partial class ModelPropertyGrid : UserControl
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

        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable;
        #endregion //Field

        #region Constructor
        public ModelPropertyGrid()
        {
            InitializeComponent();

            this.bsData = this.bsModel;
            this.dgView = this.dgvModel;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 新增行
        /// </summary>
        private void AddNew()
        {
            this.bsData.Add(new ModelProperty());
            this.bsData.ResetBindings(false);
        }

        /// <summary>
        /// 删除当前行
        /// </summary>
        private void RemoveCurrent()
        {
            int rowIndex = this.dgView.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsData.Count)
                return;

            this.bsData.RemoveAt(rowIndex);
            this.bsData.ResetBindings(false);
            return;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgView.CloseEditor();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModelPropertyGrid_Load(object sender, EventArgs e)
        {
            this.dgView.OptionsBehavior.Editable = this.editable;
            this.btnAdd.Visible = this.editable;
            this.btnDelete.Visible = this.editable;
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveCurrent();
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<ModelProperty> DataSource
        {
            get
            {
                return this.bsData.DataSource as List<ModelProperty>;
            }
            set
            {
                this.dgvModel.BeginDataUpdate();
                this.bsData.DataSource = value;
                this.dgvModel.EndDataUpdate();
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
