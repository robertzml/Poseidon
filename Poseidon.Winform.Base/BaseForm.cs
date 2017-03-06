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
    using Poseidon.Base.System;
    using Poseidon.Common;

    /// <summary>
    /// 窗体基类
    /// </summary>
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        /// <summary>
        /// 当前用户
        /// </summary>
        protected LoginUser currentUser;
        #endregion //Field

        #region Constructor
        public BaseForm()
        {
            InitializeComponent();

            this.currentUser = Cache.Instance["CurrentUser"] as LoginUser;
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
