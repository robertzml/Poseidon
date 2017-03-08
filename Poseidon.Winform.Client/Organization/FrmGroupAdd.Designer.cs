namespace Poseidon.Winform.Client
{
    partial class FrmGroupAdd
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbParent = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.bsGroup = new System.Windows.Forms.BindingSource(this.components);
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRemark = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.txtRemark = new DevExpress.XtraEditors.MemoEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(287, 15);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(178, 15);
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Size = new System.Drawing.Size(401, 271);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 271);
            this.plBottom.Size = new System.Drawing.Size(401, 60);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(401, 271);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "分组信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbParent);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtCode);
            this.layoutControl1.Controls.Add(this.txtName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(397, 248);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbParent
            // 
            this.cmbParent.Location = new System.Drawing.Point(63, 60);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbParent.Properties.DataSource = this.bsGroup;
            this.cmbParent.Properties.DisplayMember = "Name";
            this.cmbParent.Properties.NullText = "无";
            this.cmbParent.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.cmbParent.Properties.ValueMember = "Id";
            this.cmbParent.Size = new System.Drawing.Size(322, 20);
            this.cmbParent.StyleController = this.layoutControl1;
            this.cmbParent.TabIndex = 4;
            // 
            // bsGroup
            // 
            this.bsGroup.DataSource = typeof(Poseidon.Core.DL.Group);
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colCode,
            this.colRemark,
            this.colStatus});
            this.treeListLookUpEdit1TreeList.DataSource = this.bsGroup;
            this.treeListLookUpEdit1TreeList.KeyFieldName = "Id";
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.ParentFieldName = "ParentId";
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 96;
            // 
            // colCode
            // 
            this.colCode.Caption = "代码";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 96;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 2;
            this.colRemark.Width = 96;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 96;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(63, 84);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(322, 152);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(63, 36);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(322, 20);
            this.txtCode.StyleController = this.layoutControl1;
            this.txtCode.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(322, 20);
            this.txtName.StyleController = this.layoutControl1;
            this.txtName.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(397, 248);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtName;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(377, 24);
            this.layoutControlItem1.Text = "名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCode;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(377, 24);
            this.layoutControlItem2.Text = "代码";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtRemark;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(377, 156);
            this.layoutControlItem4.Text = "备注";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbParent;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(377, 24);
            this.layoutControlItem3.Text = "上级分组";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FrmGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 331);
            this.Name = "FrmGroupAdd";
            this.Text = "添加分组";
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.MemoEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TreeListLookUpEdit cmbParent;
        private System.Windows.Forms.BindingSource bsGroup;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemark;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}