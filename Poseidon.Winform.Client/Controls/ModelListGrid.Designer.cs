namespace Poseidon.Winform.Client
{
    partial class ModelListGrid
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
            this.bsModel = new System.Windows.Forms.BindingSource(this.components);
            this.dgvModel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcModel
            // 
            this.dgcModel.DataSource = this.bsModel;
            this.dgcModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcModel.Location = new System.Drawing.Point(0, 0);
            this.dgcModel.MainView = this.dgvModel;
            this.dgcModel.Name = "dgcModel";
            this.dgcModel.Size = new System.Drawing.Size(671, 386);
            this.dgcModel.TabIndex = 0;
            this.dgcModel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvModel});
            // 
            // bsModel
            // 
            this.bsModel.DataSource = typeof(Poseidon.Core.DL.CustomModel);
            // 
            // dgvModel
            // 
            this.dgvModel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colName,
            this.colBase,
            this.colType,
            this.colRemark,
            this.colId});
            this.dgvModel.GridControl = this.dgcModel;
            this.dgvModel.Name = "dgvModel";
            this.dgvModel.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvModel.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvModel.OptionsBehavior.Editable = false;
            this.dgvModel.OptionsCustomization.AllowFilter = false;
            this.dgvModel.OptionsCustomization.AllowGroup = false;
            this.dgvModel.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvModel.OptionsView.EnableAppearanceOddRow = true;
            this.dgvModel.OptionsView.ShowGroupPanel = false;
            // 
            // colKey
            // 
            this.colKey.Caption = "模型标识";
            this.colKey.FieldName = "Key";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "模型名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colBase
            // 
            this.colBase.Caption = "继承模型";
            this.colBase.FieldName = "Base";
            this.colBase.Name = "colBase";
            this.colBase.Visible = true;
            this.colBase.VisibleIndex = 3;
            // 
            // colType
            // 
            this.colType.Caption = "类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 4;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // ModelListGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcModel);
            this.Name = "ModelListGrid";
            this.Size = new System.Drawing.Size(671, 386);
            this.Load += new System.EventHandler(this.ModelListGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcModel;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvModel;
        private System.Windows.Forms.BindingSource bsModel;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBase;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}
