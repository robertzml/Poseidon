namespace Poseidon.Winform.Base
{
    partial class WinVerticalGrid
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
            this.dgcData = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgcData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcData
            // 
            this.dgcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcData.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView;
            this.dgcData.Location = new System.Drawing.Point(0, 0);
            this.dgcData.Name = "dgcData";
            this.dgcData.Size = new System.Drawing.Size(469, 415);
            this.dgcData.TabIndex = 0;
            // 
            // WinVerticalGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcData);
            this.Name = "WinVerticalGrid";
            this.Size = new System.Drawing.Size(469, 415);
            this.Load += new System.EventHandler(this.WinVerticalGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraVerticalGrid.VGridControl dgcData;
    }
}
