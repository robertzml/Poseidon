using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Core
{
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 组织表格控件
    /// </summary>
    public partial class OrganizationGrid : WinEntityGrid<Organization>
    {
        public OrganizationGrid()
        {
            InitializeComponent();           
        }
    }
}
