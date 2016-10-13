using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;

    /// <summary>
    /// 表格控件
    /// </summary>
    public partial class WinDataGrid : DevExpress.XtraEditors.XtraUserControl
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

        /// <summary>
        /// 是否显示行号
        /// </summary>
        private bool showLineNumber;

        /// <summary>
        /// 是否使用最佳宽度
        /// </summary>
        private bool bestFitColumnWidth;

        /// <summary>
        /// 是否显示CheckBox列
        /// </summary>
        private bool showCheckBox { get; set; }

        /// <summary>
        /// 字段列配置，列名和列标题
        /// </summary>
        private Dictionary<string, string> columnPairs = new Dictionary<string, string>();

        /// <summary>
        /// 列顺序
        /// </summary>
        private Dictionary<string, int> columnIndex = new Dictionary<string, int>();
        #endregion //Field

        #region Constructor
        public WinDataGrid()
        {
            InitializeComponent();

            this.bindingSource = new BindingSource();
        }
        #endregion //Constructor

        #region Function

        #endregion //Function

        #region Method
        /// <summary>
        /// 设置表格列,用'|'或','分割
        /// </summary>
        /// <param name="columnNames">列名</param>
        /// <param name="columnHeaders">列标题</param>
        public void SetColumnPairs(string columnNames, string columnHeaders)
        {
            this.columnPairs.Clear();
            this.columnIndex.Clear();

            string[] names = columnNames.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] headers = columnHeaders.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (names.Length != headers.Length)
                throw new ArgumentException("表格列配置有误");

            for (int i = 0; i < names.Length; i++)
            {
                if (!this.columnPairs.ContainsKey(names[i]))
                {
                    this.columnPairs.Add(names[i], headers[i]);
                    this.columnIndex.Add(names[i], i);
                }
            }
        }

        /// <summary>
        /// 获取选中项
        /// </summary>
        /// <returns></returns>
        public object GetSelected()
        {
            int rowIndex = this.dgvData.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bindingSource.Count)
                return null;
            else
                return this.bindingSource[rowIndex];
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bindingSource.ResetBindings(false);
        }
        #endregion //Method

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
            //先判断设置显示的列(如果没有则显示全部）
            if (this.columnPairs.Count == 0)
            {
                string tempColumns = string.Empty;

                for (int i = 0; i < this.dgvData.Columns.Count; i++)
                {
                    string originalName = this.dgvData.Columns[i].FieldName;
                    tempColumns += string.Format("{0},", originalName);
                }

                tempColumns = tempColumns.Trim(',');

                SetColumnPairs(tempColumns, tempColumns);
            }

            //设置列标题，是否显示，列顺序
            foreach (GridColumn col in this.dgvData.Columns)
            {
                string originalName = col.FieldName;
                if (this.columnPairs.ContainsKey(originalName))
                {
                    col.Caption = this.columnPairs[originalName];
                    col.VisibleIndex = this.columnIndex[originalName];
                }
                else
                {
                    col.Caption = originalName;
                    col.Visible = false;
                    col.VisibleIndex = -1;
                }
            }

            //设置特殊内容显示
            //object cellValue = "";
            //string fieldName = "";
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    for (int j = 0; j < gridView1.Columns.Count; j++)
            //    {
            //        fieldName = gridView1.Columns[j].FieldName;
            //        cellValue = gridView1.GetRowCellValue(i, fieldName);
            //        if (cellValue != null && cellValue.GetType() == typeof(DateTime))
            //        {
            //            if (cellValue != DBNull.Value)
            //            {
            //                DateTime dtTemp = DateTime.MinValue;
            //                DateTime.TryParse(cellValue.ToString(), out dtTemp);
            //                TimeSpan ts = dtTemp.Subtract(Convert.ToDateTime("1753/1/1"));
            //                if (ts.TotalDays < 1)
            //                {
            //                    gridView1.SetRowCellValue(i, fieldName, DBNull.Value);
            //                }
            //            }
            //        }
            //    }
            //}

            if (this.showLineNumber)
            {
                this.dgvData.IndicatorWidth = 40;
            }

            this.dgvData.OptionsView.ColumnAutoWidth = this.bestFitColumnWidth;
            if (this.bestFitColumnWidth)
            {
                this.dgvData.BestFitColumns();
            }

            //if (this.showCheckBox)
            //{
            //    GridCheckMarksSelection selection = new GridCheckMarksSelection(this.dgvData);
            //    selection.CheckMarkColumn.VisibleIndex = 0;
            //    selection.CheckMarkColumn.Width = 60;
            //    selection.SelectionChanged += new SelectionChangedEventHandler(selection_SelectionChanged);
            //    this.dgvData.OptionsBehavior.Editable = true;
            //    this.dgvData.OptionsBehavior.ReadOnly = false;
            //}
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (this.showLineNumber)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 行焦点改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (this.GridFocusedRowChanged != null)
            {
                GridFocusedRowChanged(sender, e);
            }
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
                this.dgvData.BeginDataUpdate();
                this.bindingSource.DataSource = value;
                if (value == null)
                {
                    this.dgcData.DataSource = null;
                }
                else
                {
                    this.dgcData.DataSource = bindingSource;
                }

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
        /// 是否显示行号
        /// </summary>
        [Description("是否显示行号")]
        public bool ShowLineNumber
        {
            get
            {
                return this.showLineNumber;
            }
            set
            {
                this.showLineNumber = value;
            }
        }

        /// <summary>
        /// 是否使用最佳宽度
        /// </summary>
        [Description("是否使用最佳宽度")]
        public bool BestFitColumnWidth
        {
            get
            {
                return this.bestFitColumnWidth;
            }
            set
            {
                this.bestFitColumnWidth = value;
            }
        }

        /// <summary>
        /// 是否显示CheckBox列
        /// </summary>
        [Description("是否显示CheckBox列")]
        public bool ShowCheckBox
        {
            get
            {
                return this.showCheckBox;
            }
            set
            {
                this.showCheckBox = value;
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
        #endregion //Property

        #region Delegate
        /// <summary>
        /// 行焦点改变事件
        /// </summary>
        [Description("行焦点改变事件")]
        public event EventHandler GridFocusedRowChanged;
        #endregion //Delegate
    }
}
