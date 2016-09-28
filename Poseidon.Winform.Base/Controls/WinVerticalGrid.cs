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
    public partial class WinVerticalGrid : UserControl
    {
        private object dataSource;//数据源


        public WinVerticalGrid()
        {
            InitializeComponent();
        }

        public void CloseEditor()
        {
            this.dgcData.CloseEditor();
        }

        public object DataSource
        {
            get { return dataSource; }
            set
            {
                //if (this.dgvData.Columns != null)
                //{
                //    this.dgvData.Columns.Clear();
                //}
                dataSource = value;
                this.dgcData.DataSource = dataSource;
            }
        }
    }
}
