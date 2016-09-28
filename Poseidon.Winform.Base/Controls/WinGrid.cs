﻿using System;
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
    using DevExpress.XtraGrid.Views.Grid;

    public partial class WinGrid : UserControl
    {
        private object dataSource;//数据源

        public WinGrid()
        {
            InitializeComponent();
        }

        public GridView GridView
        {
            get
            {
                return this.dgvData;
            }
        }

        public object DataSource
        {
            get { return dataSource; }
            set
            {
                if (this.dgvData.Columns != null)
                {
                    this.dgvData.Columns.Clear();
                }

                dataSource = value;
                this.dgcData.DataSource = dataSource;
            }
        }
    }
}