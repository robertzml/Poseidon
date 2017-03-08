namespace Poseidon.Winform.Client
{
    partial class FrmDictOverview
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnCategoryAdd = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.treeDict = new Poseidon.Winform.Core.DictTree();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCategoryEdit = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCategoryDelete = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(766, 492);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.treeDict);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.tableLayoutPanel1.SetRowSpan(this.groupControl1, 2);
            this.groupControl1.Size = new System.Drawing.Size(194, 486);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "字典列表";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.layoutControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(203, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(560, 154);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // groupControl3
            // 
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(203, 163);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(560, 326);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "groupControl3";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCategoryDelete);
            this.layoutControl1.Controls.Add(this.btnCategoryEdit);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Controls.Add(this.btnCategoryAdd);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(556, 131);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(556, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // btnCategoryAdd
            // 
            this.btnCategoryAdd.Location = new System.Drawing.Point(12, 97);
            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Size = new System.Drawing.Size(187, 22);
            this.btnCategoryAdd.StyleController = this.layoutControl1;
            this.btnCategoryAdd.TabIndex = 4;
            this.btnCategoryAdd.Text = "添加分类";
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCategoryAdd;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 85);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(191, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // treeDict
            // 
            this.treeDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDict.Location = new System.Drawing.Point(2, 21);
            this.treeDict.Name = "treeDict";
            this.treeDict.Size = new System.Drawing.Size(190, 463);
            this.treeDict.TabIndex = 0;
            this.treeDict.CategorySelected += new System.EventHandler(this.treeDict_CategorySelected);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(40, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(504, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(536, 24);
            this.layoutControlItem2.Text = "名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(24, 14);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(40, 36);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(504, 57);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtRemark;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(536, 61);
            this.layoutControlItem3.Text = "备注";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(24, 14);
            // 
            // btnCategoryEdit
            // 
            this.btnCategoryEdit.Location = new System.Drawing.Point(203, 97);
            this.btnCategoryEdit.Name = "btnCategoryEdit";
            this.btnCategoryEdit.Size = new System.Drawing.Size(168, 22);
            this.btnCategoryEdit.StyleController = this.layoutControl1;
            this.btnCategoryEdit.TabIndex = 7;
            this.btnCategoryEdit.Text = "编辑分类";
            this.btnCategoryEdit.Click += new System.EventHandler(this.btnCategoryEdit_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCategoryEdit;
            this.layoutControlItem4.Location = new System.Drawing.Point(191, 85);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(172, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // btnCategoryDelete
            // 
            this.btnCategoryDelete.Location = new System.Drawing.Point(375, 97);
            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Size = new System.Drawing.Size(169, 22);
            this.btnCategoryDelete.StyleController = this.layoutControl1;
            this.btnCategoryDelete.TabIndex = 8;
            this.btnCategoryDelete.Text = "删除分类";
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCategoryDelete;
            this.layoutControlItem5.Location = new System.Drawing.Point(363, 85);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(173, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // FrmDictOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 492);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDictOverview";
            this.Text = "字典总览";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCategoryAdd;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Core.DictTree treeDict;
        private DevExpress.XtraEditors.SimpleButton btnCategoryDelete;
        private DevExpress.XtraEditors.SimpleButton btnCategoryEdit;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}