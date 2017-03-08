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
    using Poseidon.Base.Framework;

    /// <summary>
    /// 实体表格控件
    /// </summary>
    /// <remarks>
    /// 绑定实体类
    /// </remarks>
    public partial class WinEntityGrid<T> : DevExpress.XtraEditors.XtraUserControl where T : BaseEntity
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        protected bool editable = false;

        /// <summary>
        /// 是否能筛选
        /// </summary>
        protected bool allowFilter = true;

        /// <summary>
        /// 是否能分组
        /// </summary>
        protected bool allowGroup = true;

        /// <summary>
        /// 是否能排序
        /// </summary>
        protected bool allowSort = true;

        /// <summary>
        /// 是否显示行号
        /// </summary>
        protected bool showLineNumber = true;

        /// <summary>
        /// 是否显示Footer
        /// </summary>
        protected bool showFooter = false;

        /// <summary>
        /// 是否显示新增菜单
        /// </summary>
        protected bool showAddMenu = false;
        #endregion //Field

        #region Constructor
        public WinEntityGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsEntity.ResetBindings(false);
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsEntity.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public T GetCurrentSelect()
        {
            int rowIndex = this.dgvEntity.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return null;
            else
                return this.bsEntity[rowIndex] as T;
        }

        /// <summary>
        /// 完成编辑
        /// </summary>
        public void CloseEditor()
        {
            this.dgvEntity.CloseEditor();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WinEntityGrid_Load(object sender, EventArgs e)
        {
            if (this.showLineNumber)
                this.dgvEntity.IndicatorWidth = 40;
            else
                this.dgvEntity.IndicatorWidth = 10;

            this.dgvEntity.OptionsBehavior.Editable = this.editable;
            this.dgvEntity.OptionsView.ShowFooter = this.showFooter;
            this.dgvEntity.OptionsCustomization.AllowFilter = this.allowFilter;
            this.dgvEntity.OptionsCustomization.AllowGroup = this.allowGroup;
            this.dgvEntity.OptionsCustomization.AllowSort = this.allowSort;
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
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
        /// 选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RowSelected?.Invoke(sender, e);
        }

        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            this.menuAdd.Visible = this.showAddMenu;
        }
        #endregion //Event

        #region Delegate
        /// <summary>
        /// 行选择事件
        /// </summary>
        [Description("行选择事件")]
        public event Action<object, EventArgs> RowSelected;
        #endregion //Delegate

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<T> DataSource
        {
            get
            {
                return this.bsEntity.DataSource as List<T>;
            }
            set
            {
                this.dgvEntity.BeginDataUpdate();
                this.bsEntity.DataSource = value;
                this.dgvEntity.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Category("功能"), Description("是否能编辑"), Browsable(true)]
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
        /// 是否能筛选
        /// </summary>
        [Category("功能"), Description("是否能筛选"), Browsable(true)]
        public bool AllowFilter
        {
            get
            {
                return this.allowFilter;
            }
            set
            {
                this.allowFilter = value;
            }
        }

        /// <summary>
        /// 是否能分组
        /// </summary>
        [Category("功能"), Description("是否能分组"), Browsable(true)]
        public bool AllowGroup
        {
            get
            {
                return this.allowGroup;
            }
            set
            {
                this.allowGroup = value;
            }
        }

        /// <summary>
        /// 是否能排序
        /// </summary>
        [Category("功能"), Description("是否能排序"), Browsable(true)]
        public bool AllowSort
        {
            get
            {
                return this.allowSort;
            }
            set
            {
                this.allowSort = value;
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
        /// 是否显示Footer
        /// </summary>
        [Description("是否显示Footer")]
        public bool ShowFooter
        {
            get
            {
                return this.showFooter;
            }
            set
            {
                this.showFooter = value;
            }
        }

        /// <summary>
        /// 是否显示新建菜单
        /// </summary>
        [Category("菜单"), Description("是否显示新建菜单"), Browsable(true)]
        public bool ShowAddMenu
        {
            get
            {
                return this.showAddMenu;
            }
            set
            {
                this.showAddMenu = value;
            }
        }
        #endregion //Property
    }
}
