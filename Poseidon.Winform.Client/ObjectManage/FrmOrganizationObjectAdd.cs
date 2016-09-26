using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 组织对象添加
    /// </summary>
    public partial class FrmOrganizationObjectAdd : BaseSingleForm
    {
        private OrganizationModel model = new OrganizationModel();


        public FrmOrganizationObjectAdd()
        {
            InitializeComponent();

            this.propertyGridControl1.SelectedObject = model;
        }
    }
}
