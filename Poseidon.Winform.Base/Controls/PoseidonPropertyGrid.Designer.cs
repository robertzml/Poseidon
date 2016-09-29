namespace Poseidon.Winform.Base
{
    partial class PoseidonPropertyGrid
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
            this.components = new System.ComponentModel.Container();
            this.dgcProperty = new DevExpress.XtraGrid.GridControl();
            this.dgvProperty = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bsProperty = new System.Windows.Forms.BindingSource(this.components);
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgcProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcProperty
            // 
            this.dgcProperty.DataSource = this.bsProperty;
            this.dgcProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcProperty.Location = new System.Drawing.Point(0, 0);
            this.dgcProperty.MainView = this.dgvProperty;
            this.dgcProperty.Name = "dgcProperty";
            this.dgcProperty.Size = new System.Drawing.Size(578, 375);
            this.dgcProperty.TabIndex = 0;
            this.dgcProperty.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvProperty});
            // 
            // dgvProperty
            // 
            this.dgvProperty.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colType,
            this.colRemark});
            this.dgvProperty.GridControl = this.dgcProperty;
            this.dgvProperty.Name = "dgvProperty";
            this.dgvProperty.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvProperty.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvProperty.OptionsCustomization.AllowFilter = false;
            this.dgvProperty.OptionsCustomization.AllowGroup = false;
            this.dgvProperty.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvProperty.OptionsFind.AllowFindPanel = false;
            this.dgvProperty.OptionsMenu.EnableColumnMenu = false;
            this.dgvProperty.OptionsMenu.EnableFooterMenu = false;
            this.dgvProperty.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvProperty.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvProperty.OptionsView.EnableAppearanceOddRow = true;
            this.dgvProperty.OptionsView.ShowFooter = true;
            this.dgvProperty.OptionsView.ShowGroupPanel = false;
            // 
            // bsProperty
            // 
            this.bsProperty.DataSource = typeof(Poseidon.Base.Framework.PoseidonProperty);
            // 
            // colName
            // 
            this.colName.Caption = "属性名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colType
            // 
            this.colType.Caption = "属性类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 349);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(84, 349);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PoseidonPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgcProperty);
            this.Name = "PoseidonPropertyGrid";
            this.Size = new System.Drawing.Size(578, 375);
            this.Load += new System.EventHandler(this.PoseidonPropertyGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProperty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcProperty;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvProperty;
        private System.Windows.Forms.BindingSource bsProperty;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
