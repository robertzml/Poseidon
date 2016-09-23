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
    /// 模型添加
    /// </summary>
    public partial class FrmModelAdd : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 自定义模型类型
        /// </summary>
        private CustomModelType modelType;
        #endregion //Field

        #region Constructor
        public FrmModelAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 模型添加
        /// </summary>
        /// <param name="type">自定义模型类型</param>
        public FrmModelAdd(CustomModelType type)
        {
            this.modelType = type;
            InitializeComponent();
        }
        #endregion //Constructor


    }
}
