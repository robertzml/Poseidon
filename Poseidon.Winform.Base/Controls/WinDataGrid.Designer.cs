namespace Poseidon.Winform.Base
{
    partial class WinDataGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgcData = new DevExpress.XtraGrid.GridControl();
            this.dgvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcData
            // 
            this.dgcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcData.Location = new System.Drawing.Point(0, 0);
            this.dgcData.MainView = this.dgvData;
            this.dgcData.Name = "dgcData";
            this.dgcData.Size = new System.Drawing.Size(686, 425);
            this.dgcData.TabIndex = 0;
            this.dgcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvData});
            // 
            // dgvData
            // 
            this.dgvData.GridControl = this.dgcData;
            this.dgvData.Name = "dgvData";
            this.dgvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvData.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvData.OptionsCustomization.AllowFilter = false;
            this.dgvData.OptionsCustomization.AllowGroup = false;
            this.dgvData.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvData.OptionsDetail.EnableMasterViewMode = false;
            this.dgvData.OptionsFind.AllowFindPanel = false;
            this.dgvData.OptionsMenu.EnableColumnMenu = false;
            this.dgvData.OptionsMenu.EnableFooterMenu = false;
            this.dgvData.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvData.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvData.OptionsView.EnableAppearanceOddRow = true;
            this.dgvData.OptionsView.ShowGroupPanel = false;
            this.dgvData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvData_CustomDrawRowIndicator);
            this.dgvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.dgvData_FocusedRowChanged);
            this.dgvData.DataSourceChanged += new System.EventHandler(this.dgvData_DataSourceChanged);
            // 
            // WinDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcData);
            this.Name = "WinDataGrid";
            this.Size = new System.Drawing.Size(686, 425);
            this.Load += new System.EventHandler(this.WinDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcData;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvData;
    }
}
