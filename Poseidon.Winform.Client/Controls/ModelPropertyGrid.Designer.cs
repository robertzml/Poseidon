namespace Poseidon.Winform.Client
{
    partial class ModelPropertyGrid
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
            this.dgcModel = new DevExpress.XtraGrid.GridControl();
            this.bsModelProperty = new System.Windows.Forms.BindingSource(this.components);
            this.dgvModel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgcModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsModelProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcModel
            // 
            this.dgcModel.DataSource = this.bsModelProperty;
            this.dgcModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcModel.Location = new System.Drawing.Point(0, 0);
            this.dgcModel.MainView = this.dgvModel;
            this.dgcModel.Name = "dgcModel";
            this.dgcModel.Size = new System.Drawing.Size(516, 310);
            this.dgcModel.TabIndex = 0;
            this.dgcModel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvModel});
            // 
            // bsModelProperty
            // 
            this.bsModelProperty.DataSource = typeof(Poseidon.Core.DL.ModelProperty);
            // 
            // dgvModel
            // 
            this.dgvModel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colType,
            this.colRemark});
            this.dgvModel.GridControl = this.dgcModel;
            this.dgvModel.Name = "dgvModel";
            this.dgvModel.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvModel.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvModel.OptionsCustomization.AllowFilter = false;
            this.dgvModel.OptionsCustomization.AllowGroup = false;
            this.dgvModel.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvModel.OptionsFind.AllowFindPanel = false;
            this.dgvModel.OptionsMenu.EnableColumnMenu = false;
            this.dgvModel.OptionsMenu.EnableFooterMenu = false;
            this.dgvModel.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvModel.OptionsView.EnableAppearanceOddRow = true;
            this.dgvModel.OptionsView.ShowFooter = true;
            this.dgvModel.OptionsView.ShowGroupPanel = false;
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
            this.btnAdd.Location = new System.Drawing.Point(3, 284);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(84, 284);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ModelPropertyGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgcModel);
            this.Name = "ModelPropertyGrid";
            this.Size = new System.Drawing.Size(516, 310);
            this.Load += new System.EventHandler(this.ModelPropertyGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsModelProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcModel;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvModel;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.BindingSource bsModelProperty;
    }
}
