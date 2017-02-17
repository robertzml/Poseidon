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
        #endregion //Method

        #region Event
        private void WinEntityGrid_Load(object sender, EventArgs e)
        {
        }
        #endregion //Event

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
        #endregion //Property
    }
}
