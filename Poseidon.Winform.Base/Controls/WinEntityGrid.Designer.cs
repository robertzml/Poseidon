﻿namespace Poseidon.Winform.Base
{
    partial class WinEntityGrid<T>
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
            this.dgcEntity = new DevExpress.XtraGrid.GridControl();
            this.bsEntity = new System.Windows.Forms.BindingSource();
            this.dgvEntity = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcEntity
            // 
            this.dgcEntity.DataSource = this.bsEntity;
            this.dgcEntity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcEntity.Location = new System.Drawing.Point(0, 0);
            this.dgcEntity.MainView = this.dgvEntity;
            this.dgcEntity.Name = "dgcEntity";
            this.dgcEntity.Size = new System.Drawing.Size(568, 378);
            this.dgcEntity.TabIndex = 0;
            this.dgcEntity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvEntity});
            // 
            // dgvEntity
            // 
            this.dgvEntity.GridControl = this.dgcEntity;
            this.dgvEntity.Name = "dgvEntity";
            this.dgvEntity.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.Editable = false;
            this.dgvEntity.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvEntity.OptionsView.EnableAppearanceOddRow = true;
            this.dgvEntity.OptionsView.ShowFooter = true;
            this.dgvEntity.OptionsView.ShowGroupPanel = false;
            this.dgvEntity.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvEntity_CustomDrawRowIndicator);
            // 
            // WinEntityGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcEntity);
            this.Name = "WinEntityGrid";
            this.Size = new System.Drawing.Size(568, 378);
            this.Load += new System.EventHandler(this.WinEntityGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.BindingSource bsEntity;
        protected DevExpress.XtraGrid.GridControl dgcEntity;
        protected DevExpress.XtraGrid.Views.Grid.GridView dgvEntity;
    }
}