using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Core
{
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 模型类型列表控件
    /// </summary>
    public partial class ModelTypeGrid : WinEntityGrid<ModelType>
    {
        public ModelTypeGrid()
        {
            InitializeComponent();
        }
    }
}
