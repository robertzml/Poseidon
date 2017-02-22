using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Base
{
    /// <summary>
    /// MDI窗体基类
    /// </summary>
    public partial class BaseMdiForm : BaseForm
    {
        #region Constructor
        public BaseMdiForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        #endregion //Function

        #region Event
        private void BaseMdiForm_Load(object sender, EventArgs e)
        {

        }
        #endregion //Event
    }
}
