using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    /// <summary>
    /// 窗体基类
    /// </summary>
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        #region Constructor
        public BaseForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化窗体控件和数据
        /// </summary>
        protected virtual void InitForm()
        {
        }
        #endregion //Function

        #region Event
        private void BaseForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }
        #endregion //Event
    }
}
