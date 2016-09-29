using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    using DevExpress.XtraGrid.Views.Grid;

    /// <summary>
    /// 表格控件
    /// </summary>
    public partial class WinDataGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 数据源
        /// </summary>
        private object dataSource;

        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable;

        /// <summary>
        /// 按顺序显示的列
        /// </summary>
        private string displayColumns = "";

        /// <summary>
        /// 字段列顺序
        /// </summary>
        private Dictionary<string, int> columnDict = new Dictionary<string, int>();
        #endregion //Field

        #region Constructor
        public WinDataGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinDataGrid_Load(object sender, EventArgs e)
        {
            this.dgvData.OptionsBehavior.Editable = this.editable;
        }

        /// <summary>
        /// 数据源更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_DataSourceChanged(object sender, EventArgs e)
        {

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
                return dataSource;
            }
            set
            {
                this.dgvData.BeginDataUpdate();
                if (this.dgvData.Columns != null)
                {
                    this.dgvData.Columns.Clear();
                }

                dataSource = value;
                this.dgcData.DataSource = dataSource;
                this.dgvData.EndDataUpdate();
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

        /// <summary>
        /// 表格视图
        /// </summary>
        public GridView GridView
        {
            get
            {
                return this.dgvData;
            }
        }

        /// <summary>
        /// 按顺序显示的列
        /// 用'|'或','分割
        /// </summary>
        public string DisplayColumns
        {
            get {
                return this.displayColumns; }
            set
            {
                this.displayColumns = value;
                string[] items = displayColumns.Split(new char[] { '|', ',' });
                for (int i = 0; i < items.Length; i++)
                {
                    string str = items[i];
                    if (!string.IsNullOrEmpty(str))
                    {
                        str = str.Trim();
                        if (!columnDict.ContainsKey(str.ToUpper()))
                        {
                            columnDict.Add(str.ToUpper(), i);
                        }
                    }
                }
            }
        }
        #endregion //Property

    }
}
