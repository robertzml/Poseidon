namespace Poseidon.Winform.Client
{
    partial class FrmEntityObjectOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntityObjectOverview));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tlEntityModel = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsAbstract = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsEntityModel = new System.Windows.Forms.BindingSource(this.components);
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtKey = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlEntityModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntityModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 510);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tlEntityModel);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 2);
            this.groupControl1.Size = new System.Drawing.Size(194, 504);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "实体模型列表";
            // 
            // tlEntityModel
            // 
            this.tlEntityModel.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colName,
            this.colImageIndex,
            this.colIsAbstract});
            this.tlEntityModel.DataSource = this.bsEntityModel;
            this.tlEntityModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEntityModel.KeyFieldName = "Key";
            this.tlEntityModel.Location = new System.Drawing.Point(2, 21);
            this.tlEntityModel.Name = "tlEntityModel";
            this.tlEntityModel.OptionsBehavior.Editable = false;
            this.tlEntityModel.OptionsBehavior.PopulateServiceColumns = true;
            this.tlEntityModel.ParentFieldName = "Base";
            this.tlEntityModel.RootValue = "EntityModel";
            this.tlEntityModel.SelectImageList = this.imageCollection1;
            this.tlEntityModel.Size = new System.Drawing.Size(190, 481);
            this.tlEntityModel.TabIndex = 0;
            this.tlEntityModel.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.tlEntityModel_GetSelectImage);
            this.tlEntityModel.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlEntityModel_FocusedNodeChanged);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 342;
            // 
            // colName
            // 
            this.colName.Caption = "模型名称";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 33;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 287;
            // 
            // colImageIndex
            // 
            this.colImageIndex.Caption = "图标索引";
            this.colImageIndex.Name = "colImageIndex";
            this.colImageIndex.UnboundExpression = "[IsAbstract] = True";
            this.colImageIndex.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            // 
            // colIsAbstract
            // 
            this.colIsAbstract.Caption = "是否抽象类";
            this.colIsAbstract.FieldName = "IsAbstract";
            this.colIsAbstract.Name = "colIsAbstract";
            // 
            // bsEntityModel
            // 
            this.bsEntityModel.DataSource = typeof(Poseidon.Core.DL.EntityModel);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("content_16x16.png", "images/miscellaneous/content_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/miscellaneous/content_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "content_16x16.png");
            this.imageCollection1.InsertGalleryImage("product_16x16.png", "images/support/product_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/support/product_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "product_16x16.png");
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(203, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(606, 144);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "模型基本信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.txtKey);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(602, 121);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(602, 121);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(64, 12);
            this.txtKey.Name = "txtKey";
            this.txtKey.Properties.ReadOnly = true;
            this.txtKey.Size = new System.Drawing.Size(235, 20);
            this.txtKey.StyleController = this.layoutControl1;
            this.txtKey.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtKey;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(291, 101);
            this.layoutControlItem1.Text = "模型标识";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(355, 12);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(291, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(291, 101);
            this.layoutControlItem2.Text = "模型名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FrmEntityObjectOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 510);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmEntityObjectOverview";
            this.Text = "实体对象总览";
            this.Load += new System.EventHandler(this.FrmEntityObjectOverview_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlEntityModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntityModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList tlEntityModel;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource bsEntityModel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImageIndex;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsAbstract;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtKey;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}